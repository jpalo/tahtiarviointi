﻿using com.jussipalo.tahti.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace com.jussipalo.tahti
{
    static class ExcelWorker
    {
        private static void GenerateAllSkatersWorksheet(ExcelPackage ep, string tulosPohja, string tapahtumaSarja, string aikaJaPaikka, List<Skater> finalSkaters)
        {
            try
            {
                var ws = ep.Workbook.Worksheets.Add("Kaikki");
                ws.PrinterSettings.Orientation = eOrientation.Landscape;
                ws.Cells["A1:H1"].Merge = true;

                ws.Cells["A1"].Value = tapahtumaSarja + ", " + aikaJaPaikka;

                ws.Cells["A2"].Value = "Järj.";
                ws.Cells["B2"].Value = "Sij.";
                ws.Cells["C2"].Value = "Nimi";
                ws.Cells["D2"].Value = "Seura";
                ws.Cells["E2"].Value = "T1";
                ws.Cells["F2"].Value = "T2";
                ws.Cells["G2"].Value = "T3";
                ws.Cells["H2"].Value = "Osa-alue";

                ws.Cells["A3"].LoadFromArrays(SkaterListToArray(finalSkaters, tulosPohja));

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                ep.Workbook.Worksheets.MoveToStart("Kaikki");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sattui iso virhe! " + ex.Message);
            }
        }

        private static List<string[]> SkaterListToArray(List<Skater> finalSkaters, string tulosPohja)
        {
            var flatSkaters = new List<string[]>();

            for (int s = 0; s < finalSkaters.Count; s++)
            {
                for (int p = 0; p < finalSkaters[s].PointsJudge1.Count; p++)
                {
                    flatSkaters.Add(new string[] { finalSkaters[s].SkatingOrder.ToString(), finalSkaters[s].Position.ToString(), finalSkaters[s].Name,
                        finalSkaters[s].Team, finalSkaters[s].PointsJudge1[p].ToString(), finalSkaters[s].PointsJudge2[p].ToString(),
                        finalSkaters[s].PointsJudge3[p].ToString(), GetArea(p, tulosPohja) });
                }
            }

            return flatSkaters;
        }

        private static string GetArea(int area, string tulosPohja)
        {
            if (tulosPohja.ToLower().Contains("laaja"))
            {
                return Common.ExtendedAreas[area];
            }
            else
            {
                return Common.BasicAreas[area];
            }
        }

        /// <summary>
        /// Generates result Excel containing score papers to be given to skaters as well as combines paper for judges
        /// </summary>
        /// <param name="tulosPohja"></param>
        public static string GenerateResultFile(string tulosPohja, string templateFile, string tapahtumaSarja, string aikaJaPaikka, List<Skater> finalSkaters, string outputFolder)
        {
            string generatedFile = "";

            ExcelPackage ep = null;

            try
            {
                // Get circle
                Bitmap circle = new Bitmap(Resources.circle);

                ep = new ExcelPackage(new FileInfo(templateFile), true);

                if (ep == null)
                {
                    MessageBox.Show("Tulospohjaa ei ole valittu tai tulospohjan avaamisessa tapahtui virhe.");
                    return "";
                }

                var wb = ep.Workbook;
                var ws = wb.Worksheets["Template"];

                wb.Names["Tapahtuma_ja_sarja"].Value = tapahtumaSarja;
                wb.Names["Aika_ja_paikka"].Value = aikaJaPaikka;

                foreach (var skater in finalSkaters)
                {
                    wb.Names["Nimi"].Value = skater.Name;
                    wb.Names["Seura"].Value = skater.Team;

                    for (int i = 0; i < skater.AveragePointsPerArea.Count; i++)
                    {
                        wb.Names["Pisteet" + (i + 1).ToString()].Value = FormatFraction(skater.AveragePointsPerArea[i]);

                        var picture = ws.Drawings.AddPicture(skater.SkatingOrder + "_" + "StarPicture" + (i + 1).ToString(), circle);

                        picture.SetPosition(
                            wb.Names["Pisteet" + (i + 1).ToString()].Start.Row,
                            -54,
                            wb.Names["Pisteet" + (i + 1).ToString()].Start.Column,
                            CalculateCirclePosition(skater.CircledPoints[i], tulosPohja)
                            );
                    }

                    wb.Names["PisteetTotal"].Value = Math.Round(skater.TotalPoints, 2, MidpointRounding.AwayFromZero);

                    if (skater.Position == 0)
                    {
                        // In basic, only display position to first 3 skaters
                        wb.Names["Sija"].Value = "";
                    }
                    else
                    {
                        wb.Names["Sija"].Value = skater.Position + ".";
                    }

                    if (!string.IsNullOrWhiteSpace(skater.Mention))
                    {
                        wb.Names["Erikoismaininnat"].Value = "Erikoismaininta: " + skater.Mention;
                    }
                    else
                    {
                        wb.Names["Erikoismaininnat"].Value = "";
                    }

                    if (skater.Deductions.Count > 0)
                    {
                        if (skater.Deductions[1].Equals(0.0))
                        {
                        }

                        wb.Names["Liukuvahennys"].Value = skater.Deductions[0].Equals(0) ? "" : Math.Round(skater.Deductions[0], 1, MidpointRounding.AwayFromZero).ToString();
                        wb.Names["Aikavahennys"].Value = skater.Deductions[1].Equals(0) ? "" : Math.Round(skater.Deductions[1], 1, MidpointRounding.AwayFromZero).ToString();
                        wb.Names["Pukuvahennys"].Value = skater.Deductions[2].Equals(0) ? "" : Math.Round(skater.Deductions[2], 1, MidpointRounding.AwayFromZero).ToString();
                    }
                    else
                    {
                        wb.Names["Liukuvahennys"].Value = "";
                        wb.Names["Aikavahennys"].Value = "";
                        wb.Names["Pukuvahennys"].Value = "";
                    }

                    wb.Worksheets.Add(skater.Name, wb.Worksheets["Template"]);

                    // Remove star pictures
                    var drawingCollection = ws.Drawings.Where(d => d.Name.Contains("StarPicture")).Select(d => d.Name).ToList();

                    foreach (string drawingName in drawingCollection)
                    {
                        //ws.Drawings.Remove(drawingName);
                        ws.Drawings[drawingName].SetSize(0, 0);
                    }
                }

                // Finally empty template worksheet
                wb.Names["Tapahtuma_ja_sarja"].Value = "";
                wb.Names["Aika_ja_paikka"].Value = "";
                wb.Names["Nimi"].Value = "";
                wb.Names["Seura"].Value = "";
                wb.Names["PisteetTotal"].Value = "";
                wb.Names["Sija"].Value = "";
                wb.Names["Erikoismaininnat"].Value = "";

                for (int i = 0; i < finalSkaters[0].AveragePointsPerArea.Count; i++)
                {
                    wb.Names["Pisteet" + (i + 1).ToString()].Value = "";
                }

                // Fix image sizes
                foreach (ExcelPicture drawing in ws.Drawings.Where(p => p.Name.Contains("Star")))
                {
                    drawing.SetSize(100);
                }

                // Generate sheet containing all skaters and their points
                GenerateAllSkatersWorksheet(ep, tulosPohja, tapahtumaSarja, aikaJaPaikka, finalSkaters);

                // Finally move template sheet to end and hide it
                wb.Worksheets.MoveToEnd("Template");
                ws.Hidden = eWorkSheetHidden.Hidden;

                generatedFile = outputFolder + "\\" + Common.CreateValidFilename(aikaJaPaikka + "_" + tapahtumaSarja + "_" + DateTime.Now.ToString("yyyyMMdd")) + ".xlsx";
                ep.SaveAs(new FileInfo(generatedFile));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sattui iso virhe! " + ex.Message);
            }
            finally
            {
                if (ep != null)
                {
                    ep.Dispose();
                }
            }

            return generatedFile;
        }

        /// <summary>
        /// Converts decimal into rational number with fractions part, 2.33 becomes 2 1/3. Note! Only supports X.00, X.33 and X.67 decimal parts.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string FormatFraction(decimal x)
        {
            x = Math.Round(x, 2);

            int ipart = (int)x;
            decimal fpart = Math.Round(x - ipart, 2, MidpointRounding.AwayFromZero);

            string fpartString = "";

            switch (fpart.ToString(CultureInfo.InvariantCulture))
            {
                case ("0.33"):
                    fpartString = " 1/3";
                    return ipart.ToString() + fpartString;

                case ("0.5"):
                    fpartString = " 1/2";
                    return ipart.ToString() + fpartString;

                case ("0.67"):
                    fpartString = " 2/3";
                    return ipart.ToString() + fpartString;

                case ("0"):
                case ("0.00"):
                    return ipart.ToString();
            }

            throw new Exception("Virheellinen pistemäärä havaittu: " + x.ToString());
        }

        private static int CalculateCirclePosition(int circledPoints, string tulospohja)
        {
            if (tulospohja.Contains("laaja"))
            {
                int[] left = { 458, 425, 385, 345, 304, 259, 206, 152 };
                return -1 * left[circledPoints - 1];
            }
            else
            {
                int[] left = { 458, 407, 351, 295, 235, 163 };
                return -1 * left[circledPoints - 1];
            }
        }
    }
}