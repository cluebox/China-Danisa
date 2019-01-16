using SpssLib.DataReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaina_Danisa_Parsing
{
    class Chaina_Danisa_Parsing
    {
        static void Main(string[] args)
        {
            int SurveyID = 600528;
            //string SurveyPeriod = "2014-09-30";//survey period
            string SurveyPeriod = "2015-05-31";
            string Country = "China";//survey country
            DB_insertion_China_Danisa iobj = new DB_insertion_China_Danisa();
            string questions = "respid,Weight,period,q1,q5,q52,q3,q48,q51,q10,q18a,q63a,q63b_2,q63b_1,q63b_3,q63b_5,q63b_9,q63b_14,q63b_15,q63b_22,q63b_23,q64a_2,q64a_1,q64a_3,q64a_5,q64a_9,q64a_14,q64a_15,q64a_22,q64a_23,q16a,q16b_2,q16b_1,q16b_3,q16b_5,q16b_9,q16b_14,q16b_15,q16b_22,q16b_23,q16f_2,q16f_1,q16f_3,q16f_5,q16f_9,q16f_14,q16f_15,q16f_22,q16f_23,q21a,q21b,q18c,q18a_2,q18a_1,q18a_3,q18a_5,q18a_9,q18a_14,q18a_15,q18a_22,q18a_23,q18b_2,q18b_1,q18b_3,q18b_5,q18b_9,q18b_14,q18b_15,q18b_22,q18b_23,q21c,q20_2,q20_1,q20_3,q20_5,q20_9,q20_14,q20_15,q20_22,q20_23,q22_2,q22_1,q22_3,q22_5,q22_9,q22_14,q22_15,q22_22,q22_23,q19,q67a_1,q67a_2,q67a_3,q67a_4,q67a_5,q67a_6,q67a_7,q67a_8,q67b,q55a,q56a_1,q56a_2,q56a_3,q56a_4,q56a_5,q56a_6,q56a_7,q56a_8,q68a_1,q68a_2,q68a_3,q68a_4,q68a_5,q68a_6,q68a_7,q68a_8,q68b,q55b,q56b_1,q56b_2,q56b_3,q56b_4,q56b_5,q56b_6,q56b_7,q56b_8,q15,q23_1_1,q23_1_2,q23_1_3,q23_1_4,q23_1_5,q23_1_6,q23_1_7,q23_1_8,q23_1_9,q23_1_10,q23_1_11,q23_1_12,q23_1_13,q23_1_14,q23_2_1,q23_2_2,q23_2_3,q23_2_4,q23_2_5,q23_2_6,q23_2_7,q23_2_8,q23_2_9,q23_2_10,q23_2_11,q23_2_12,q23_2_13,q23_2_14,q23_3_1,q23_3_2,q23_3_3,q23_3_4,q23_3_5,q23_3_6,q23_3_7,q23_3_8,q23_3_9,q23_3_10,q23_3_11,q23_3_12,q23_3_13,q23_3_14,q23_5_1,q23_5_2,q23_5_3,q23_5_4,q23_5_5,q23_5_6,q23_5_7,q23_5_8,q23_5_9,q23_5_10,q23_5_11,q23_5_12,q23_5_13,q23_5_14,q23_9_1,q23_9_2,q23_9_3,q23_9_4,q23_9_5,q23_9_6,q23_9_7,q23_9_8,q23_9_9,q23_9_10,q23_9_11,q23_9_12,q23_9_13,q23_9_14,q16c,q16d_2,q16d_1,q16d_3,q16d_5,q16d_9,q16d_14,q16d_15,q16d_22,q16d_23";// dashboard variable value   
           
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"D:\Mysql_to_Xl\China-danisa\DAN-MAY-2015.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                                //iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, Country, BASE_VARIABLE_NAME, SurveyPeriod);
                            }
                        }

                    }
                }
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string variable_name;
                    string u_id = null;
                    decimal Weight = 0;
                    string Period = "-- Not Available --";
                    string Location = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string Gender = "-- Not Available --";
                    string MaritalStatus = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string Income = "-- Not Available --";
                    string Danisa_cookie_base = "-- Not Available --";
                    string BrTom = "-- Not Available --";
                    string BrSpont_MayoraDanisa = "-- Not Available --";
                    string BrSpont_MONDELEZChipsAhoy = "-- Not Available --";
                    string BrSpont_KelsenKjeldsens = "-- Not Available --";
                    string BrSpont_MONDELEZOreo = "-- Not Available --";
                    string BrSpont_Glico = "-- Not Available --";
                    string BrSpont_Daliyuan = "-- Not Available --";
                    string BrSpont_Garden = "-- Not Available --";
                    string BrSpont_Astick = "-- Not Available --";
                    string BrSpont_Better = "-- Not Available --";
                    string BrAid_MayoraDanisa = "-- Not Available --";
                    string BrAid_MONDELEZChipsAhoy = "-- Not Available --";
                    string BrAid_KelsenKjeldsens = "-- Not Available --";
                    string BrAid_MONDELEZOreo = "-- Not Available --";
                    string BrAid_Glico = "-- Not Available --";
                    string BrAid_Daliyuan = "-- Not Available --";
                    string BrAid_Garden = "-- Not Available --";
                    string BrAid_Astick = "-- Not Available --";
                    string BrAid_Better = "-- Not Available --";
                    string AdTom = "-- Not Available --";
                    string AdSpont_MayoraDanisa = "-- Not Available --";
                    string AdSpont_MONDELEZChipsAhoy = "-- Not Available --";
                    string AdSpont_KelsenKjeldsens = "-- Not Available --";
                    string AdSpont_MONDELEZOreo = "-- Not Available --";
                    string AdSpont_Glico = "-- Not Available --";
                    string AdSpont_Daliyuan = "-- Not Available --";
                    string AdSpont_Garden = "-- Not Available --";
                    string AdSpont_Astick = "-- Not Available --";
                    string AdSpont_Better = "-- Not Available --";
                    string AdAid_MayoraDanisa = "-- Not Available --";
                    string AdAid_MONDELEZChipsAhoy = "-- Not Available --";
                    string AdAid_KelsenKjeldsens = "-- Not Available --";
                    string AdAid_MONDELEZOreo = "-- Not Available --";
                    string AdAid_Glico = "-- Not Available --";
                    string AdAid_Daliyuan = "-- Not Available --";
                    string AdAid_Garden = "-- Not Available --";
                    string AdAid_Astick = "-- Not Available --";
                    string AdAid_Better = "-- Not Available --";
                    string Favourite_Brand = "-- Not Available --";
                    string Sec_Favourite_Brand = "-- Not Available --";
                    string Bumo = "-- Not Available --";
                    string ConL3M_MayoraDanisa = "-- Not Available --";
                    string ConL3M_MONDELEZChipsAhoy = "-- Not Available --";
                    string ConL3M_KelsenKjeldsens = "-- Not Available --";
                    string ConL3M_MONDELEZOreo = "-- Not Available --";
                    string ConL3M_Glico = "-- Not Available --";
                    string ConL3M_Daliyuan = "-- Not Available --";
                    string ConL3M_Garden = "-- Not Available --";
                    string ConL3M_Astick = "-- Not Available --";
                    string ConL3M_Better = "-- Not Available --";
                    string ConL1M_MayoraDanisa = "-- Not Available --";
                    string ConL1M_MONDELEZChipsAhoy = "-- Not Available --";
                    string ConL1M_KelsenKjeldsens = "-- Not Available --";
                    string ConL1M_MONDELEZOreo = "-- Not Available --";
                    string ConL1M_Glico = "-- Not Available --";
                    string ConL1M_Daliyuan = "-- Not Available --";
                    string ConL1M_Garden = "-- Not Available --";
                    string ConL1M_Astick = "-- Not Available --";
                    string ConL1M_Better = "-- Not Available --";
                    string Recommend_Brand = "-- Not Available --";
                    string q20_2 = "-- Not Available --";
                    string q20_1 = "-- Not Available --";
                    string q20_3 = "-- Not Available --";
                    string q20_5 = "-- Not Available --";
                    string q20_9 = "-- Not Available --";
                    string q20_14 = "-- Not Available --";
                    string q20_15 = "-- Not Available --";
                    string q20_22 = "-- Not Available --";
                    string q20_23 = "-- Not Available --";
                    string q22_2 = "-- Not Available --";
                    string q22_1 = "-- Not Available --";
                    string q22_3 = "-- Not Available --";
                    string q22_5 = "-- Not Available --";
                    string q22_9 = "-- Not Available --";
                    string q22_14 = "-- Not Available --";
                    string q22_15 = "-- Not Available --";
                    string q22_22 = "-- Not Available --";
                    string q22_23 = "-- Not Available --";
                    string q19 = "-- Not Available --";
                    string q67a_1 = "-- Not Available --";
                    string q67a_2 = "-- Not Available --";
                    string q67a_3 = "-- Not Available --";
                    string q67a_4 = "-- Not Available --";
                    string q67a_5 = "-- Not Available --";
                    string q67a_6 = "-- Not Available --";
                    string q67a_7 = "-- Not Available --";
                    string q67a_8 = "-- Not Available --";
                    string q67b = "-- Not Available --";
                    string q55a = "-- Not Available --";
                    string q56a_1 = "-- Not Available --";
                    string q56a_2 = "-- Not Available --";
                    string q56a_3 = "-- Not Available --";
                    string q56a_4 = "-- Not Available --";
                    string q56a_5 = "-- Not Available --";
                    string q56a_6 = "-- Not Available --";
                    string q56a_7 = "-- Not Available --";
                    string q56a_8 = "-- Not Available --";
                    string q68a_1 = "-- Not Available --";
                    string q68a_2 = "-- Not Available --";
                    string q68a_3 = "-- Not Available --";
                    string q68a_4 = "-- Not Available --";
                    string q68a_5 = "-- Not Available --";
                    string q68a_6 = "-- Not Available --";
                    string q68a_7 = "-- Not Available --";
                    string q68a_8 = "-- Not Available --";
                    string q68b = "-- Not Available --";
                    string q55b = "-- Not Available --";
                    string q56b_1 = "-- Not Available --";
                    string q56b_2 = "-- Not Available --";
                    string q56b_3 = "-- Not Available --";
                    string q56b_4 = "-- Not Available --";
                    string q56b_5 = "-- Not Available --";
                    string q56b_6 = "-- Not Available --";
                    string q56b_7 = "-- Not Available --";
                    string q56b_8 = "-- Not Available --";
                    string q15 = "-- Not Available --";
                    string q23_1_1 = "-- Not Available --";
                    string q23_1_2 = "-- Not Available --";
                    string q23_1_3 = "-- Not Available --";
                    string q23_1_4 = "-- Not Available --";
                    string q23_1_5 = "-- Not Available --";
                    string q23_1_6 = "-- Not Available --";
                    string q23_1_7 = "-- Not Available --";
                    string q23_1_8 = "-- Not Available --";
                    string q23_1_9 = "-- Not Available --";
                    string q23_1_10 = "-- Not Available --";
                    string q23_1_11 = "-- Not Available --";
                    string q23_1_12 = "-- Not Available --";
                    string q23_1_13 = "-- Not Available --";
                    string q23_1_14 = "-- Not Available --";
                    string q23_2_1 = "-- Not Available --";
                    string q23_2_2 = "-- Not Available --";
                    string q23_2_3 = "-- Not Available --";
                    string q23_2_4 = "-- Not Available --";
                    string q23_2_5 = "-- Not Available --";
                    string q23_2_6 = "-- Not Available --";
                    string q23_2_7 = "-- Not Available --";
                    string q23_2_8 = "-- Not Available --";
                    string q23_2_9 = "-- Not Available --";
                    string q23_2_10 = "-- Not Available --";
                    string q23_2_11 = "-- Not Available --";
                    string q23_2_12 = "-- Not Available --";
                    string q23_2_13 = "-- Not Available --";
                    string q23_2_14 = "-- Not Available --";
                    string q23_3_1 = "-- Not Available --";
                    string q23_3_2 = "-- Not Available --";
                    string q23_3_3 = "-- Not Available --";
                    string q23_3_4 = "-- Not Available --";
                    string q23_3_5 = "-- Not Available --";
                    string q23_3_6 = "-- Not Available --";
                    string q23_3_7 = "-- Not Available --";
                    string q23_3_8 = "-- Not Available --";
                    string q23_3_9 = "-- Not Available --";
                    string q23_3_10 = "-- Not Available --";
                    string q23_3_11 = "-- Not Available --";
                    string q23_3_12 = "-- Not Available --";
                    string q23_3_13 = "-- Not Available --";
                    string q23_3_14 = "-- Not Available --";
                    string q23_5_1 = "-- Not Available --";
                    string q23_5_2 = "-- Not Available --";
                    string q23_5_3 = "-- Not Available --";
                    string q23_5_4 = "-- Not Available --";
                    string q23_5_5 = "-- Not Available --";
                    string q23_5_6 = "-- Not Available --";
                    string q23_5_7 = "-- Not Available --";
                    string q23_5_8 = "-- Not Available --";
                    string q23_5_9 = "-- Not Available --";
                    string q23_5_10 = "-- Not Available --";
                    string q23_5_11 = "-- Not Available --";
                    string q23_5_12 = "-- Not Available --";
                    string q23_5_13 = "-- Not Available --";
                    string q23_5_14 = "-- Not Available --";
                    string q23_9_1 = "-- Not Available --";
                    string q23_9_2 = "-- Not Available --";
                    string q23_9_3 = "-- Not Available --";
                    string q23_9_4 = "-- Not Available --";
                    string q23_9_5 = "-- Not Available --";
                    string q23_9_6 = "-- Not Available --";
                    string q23_9_7 = "-- Not Available --";
                    string q23_9_8 = "-- Not Available --";
                    string q23_9_9 = "-- Not Available --";
                    string q23_9_10 = "-- Not Available --";
                    string q23_9_11 = "-- Not Available --";
                    string q23_9_12 = "-- Not Available --";
                    string q23_9_13 = "-- Not Available --";
                    string q23_9_14 = "-- Not Available --";
                    string Tom_Cookie = "-- Not Available --";
                    string Br_cookie_MayoraDanisa = "-- Not Available --";
                    string Br_cookie_MONDELEZChipsAhoy = "-- Not Available --";
                    string Br_cookie_KelsenKjeldsens = "-- Not Available --";
                    string Br_cookie_MONDELEZOreo = "-- Not Available --";
                    string Br_cookie_Glico = "-- Not Available --";
                    string Br_cookie_Daliyuan = "-- Not Available --";
                    string Br_cookie_Garden = "-- Not Available --";
                    string Br_cookie_Astick = "-- Not Available --";
                    string Br_cookie_Better = "-- Not Available --";

                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;
                                switch (variable_name)
                                {
                                    case "respid":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SurveyID, SurveyPeriod, u_id);
                                            break;
                                        }
                                    case "Weight":
                                        {
                                            Weight = Convert.ToDecimal(record.GetValue(variable));
                                            break;
                                        }
                                    case "period":
                                        {
                                            Period = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q1":
                                        {
                                            Location = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q5":
                                        {
                                            AgeGroup = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q52":
                                        {
                                            Occupation = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q3":
                                        {
                                            Gender = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q48":
                                        {
                                            MaritalStatus = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q51":
                                        {
                                            Education = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q10":
                                        {
                                            Income = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a":
                                        {
                                            Danisa_cookie_base = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63a":
                                        {
                                            BrTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_2":
                                        {
                                            BrSpont_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_1":
                                        {
                                            BrSpont_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_3":
                                        {
                                            BrSpont_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_5":
                                        {
                                            BrSpont_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_9":
                                        {
                                            BrSpont_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_14":
                                        {
                                            BrSpont_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_15":
                                        {
                                            BrSpont_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_22":
                                        {
                                            BrSpont_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q63b_23":
                                        {
                                            BrSpont_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_2":
                                        {
                                            BrAid_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_1":
                                        {
                                            BrAid_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_3":
                                        {
                                            BrAid_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_5":
                                        {
                                            BrAid_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_9":
                                        {
                                            BrAid_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_14":
                                        {
                                            BrAid_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_15":
                                        {
                                            BrAid_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_22":
                                        {
                                            BrAid_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q64a_23":
                                        {
                                            BrAid_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16c":
                                        {
                                            AdTom = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_2":
                                        {
                                            AdSpont_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_1":
                                        {
                                            AdSpont_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_3":
                                        {
                                            AdSpont_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_5":
                                        {
                                            AdSpont_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_9":
                                        {
                                            AdSpont_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_14":
                                        {
                                            AdSpont_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_15":
                                        {
                                            AdSpont_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_22":
                                        {
                                            AdSpont_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16d_23":
                                        {
                                            AdSpont_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_2":
                                        {
                                            AdAid_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_1":
                                        {
                                            AdAid_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_3":
                                        {
                                            AdAid_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_5":
                                        {
                                            AdAid_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_9":
                                        {
                                            AdAid_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_14":
                                        {
                                            AdAid_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_15":
                                        {
                                            AdAid_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_22":
                                        {
                                            AdAid_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16f_23":
                                        {
                                            AdAid_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q21a":
                                        {
                                            Favourite_Brand = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q21b":
                                        {
                                            Sec_Favourite_Brand = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18c":
                                        {
                                            Bumo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_2":
                                        {
                                            ConL3M_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_1":
                                        {
                                            ConL3M_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_3":
                                        {
                                            ConL3M_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_5":
                                        {
                                            ConL3M_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_9":
                                        {
                                            ConL3M_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_14":
                                        {
                                            ConL3M_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_15":
                                        {
                                            ConL3M_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_22":
                                        {
                                            ConL3M_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18a_23":
                                        {
                                            ConL3M_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_2":
                                        {
                                            ConL1M_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_1":
                                        {
                                            ConL1M_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_3":
                                        {
                                            ConL1M_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_5":
                                        {
                                            ConL1M_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_9":
                                        {
                                            ConL1M_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_14":
                                        {
                                            ConL1M_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_15":
                                        {
                                            ConL1M_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_22":
                                        {
                                            ConL1M_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q18b_23":
                                        {
                                            ConL1M_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q21c":
                                        {
                                            Recommend_Brand = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_2":
                                        {
                                            q20_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_1":
                                        {
                                            q20_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_3":
                                        {
                                            q20_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_5":
                                        {
                                            q20_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_9":
                                        {
                                            q20_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_14":
                                        {
                                            q20_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_15":
                                        {
                                            q20_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_22":
                                        {
                                            q20_22 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q20_23":
                                        {
                                            q20_23 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_2":
                                        {
                                            q22_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_1":
                                        {
                                            q22_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_3":
                                        {
                                            q22_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_5":
                                        {
                                            q22_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_9":
                                        {
                                            q22_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_14":
                                        {
                                            q22_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_15":
                                        {
                                            q22_15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_22":
                                        {
                                            q22_22 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q22_23":
                                        {
                                            q22_23 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q19":
                                        {
                                            q19 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_1":
                                        {
                                            q67a_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_2":
                                        {
                                            q67a_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_3":
                                        {
                                            q67a_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_4":
                                        {
                                            q67a_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_5":
                                        {
                                            q67a_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_6":
                                        {
                                            q67a_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_7":
                                        {
                                            q67a_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67a_8":
                                        {
                                            q67a_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q67b":
                                        {
                                            q67b = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q55a":
                                        {
                                            q55a = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_1":
                                        {
                                            q56a_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_2":
                                        {
                                            q56a_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_3":
                                        {
                                            q56a_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_4":
                                        {
                                            q56a_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_5":
                                        {
                                            q56a_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_6":
                                        {
                                            q56a_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_7":
                                        {
                                            q56a_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56a_8":
                                        {
                                            q56a_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_1":
                                        {
                                            q68a_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_2":
                                        {
                                            q68a_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_3":
                                        {
                                            q68a_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_4":
                                        {
                                            q68a_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_5":
                                        {
                                            q68a_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_6":
                                        {
                                            q68a_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_7":
                                        {
                                            q68a_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68a_8":
                                        {
                                            q68a_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q68b":
                                        {
                                            q68b = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q55b":
                                        {
                                            q55b = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_1":
                                        {
                                            q56b_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_2":
                                        {
                                            q56b_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_3":
                                        {
                                            q56b_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_4":
                                        {
                                            q56b_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_5":
                                        {
                                            q56b_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_6":
                                        {
                                            q56b_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_7":
                                        {
                                            q56b_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q56b_8":
                                        {
                                            q56b_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q15":
                                        {
                                            q15 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_1":
                                        {
                                            q23_1_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_2":
                                        {
                                            q23_1_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_3":
                                        {
                                            q23_1_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_4":
                                        {
                                            q23_1_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_5":
                                        {
                                            q23_1_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_6":
                                        {
                                            q23_1_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_7":
                                        {
                                            q23_1_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_8":
                                        {
                                            q23_1_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_9":
                                        {
                                            q23_1_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_10":
                                        {
                                            q23_1_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_11":
                                        {
                                            q23_1_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_12":
                                        {
                                            q23_1_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_13":
                                        {
                                            q23_1_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_1_14":
                                        {
                                            q23_1_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_1":
                                        {
                                            q23_2_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_2":
                                        {
                                            q23_2_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_3":
                                        {
                                            q23_2_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_4":
                                        {
                                            q23_2_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_5":
                                        {
                                            q23_2_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_6":
                                        {
                                            q23_2_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_7":
                                        {
                                            q23_2_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_8":
                                        {
                                            q23_2_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_9":
                                        {
                                            q23_2_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_10":
                                        {
                                            q23_2_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_11":
                                        {
                                            q23_2_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_12":
                                        {
                                            q23_2_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_13":
                                        {
                                            q23_2_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_2_14":
                                        {
                                            q23_2_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_1":
                                        {
                                            q23_3_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_2":
                                        {
                                            q23_3_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_3":
                                        {
                                            q23_3_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_4":
                                        {
                                            q23_3_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_5":
                                        {
                                            q23_3_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_6":
                                        {
                                            q23_3_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_7":
                                        {
                                            q23_3_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_8":
                                        {
                                            q23_3_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_9":
                                        {
                                            q23_3_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_10":
                                        {
                                            q23_3_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_11":
                                        {
                                            q23_3_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_12":
                                        {
                                            q23_3_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_13":
                                        {
                                            q23_3_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_3_14":
                                        {
                                            q23_3_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_1":
                                        {
                                            q23_5_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_2":
                                        {
                                            q23_5_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_3":
                                        {
                                            q23_5_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_4":
                                        {
                                            q23_5_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_5":
                                        {
                                            q23_5_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_6":
                                        {
                                            q23_5_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_7":
                                        {
                                            q23_5_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_8":
                                        {
                                            q23_5_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_9":
                                        {
                                            q23_5_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_10":
                                        {
                                            q23_5_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_11":
                                        {
                                            q23_5_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_12":
                                        {
                                            q23_5_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_13":
                                        {
                                            q23_5_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_5_14":
                                        {
                                            q23_5_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_1":
                                        {
                                            q23_9_1 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_2":
                                        {
                                            q23_9_2 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_3":
                                        {
                                            q23_9_3 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_4":
                                        {
                                            q23_9_4 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_5":
                                        {
                                            q23_9_5 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_6":
                                        {
                                            q23_9_6 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_7":
                                        {
                                            q23_9_7 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_8":
                                        {
                                            q23_9_8 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_9":
                                        {
                                            q23_9_9 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_10":
                                        {
                                            q23_9_10 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_11":
                                        {
                                            q23_9_11 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_12":
                                        {
                                            q23_9_12 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_13":
                                        {
                                            q23_9_13 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q23_9_14":
                                        {
                                            q23_9_14 = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16a":
                                        {
                                            Tom_Cookie = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_2":
                                        {
                                            Br_cookie_MayoraDanisa = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_1":
                                        {
                                            Br_cookie_MONDELEZChipsAhoy = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_3":
                                        {
                                            Br_cookie_KelsenKjeldsens = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_5":
                                        {
                                            Br_cookie_MONDELEZOreo = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_9":
                                        {
                                            Br_cookie_Glico = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_14":
                                        {
                                            Br_cookie_Daliyuan = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_15":
                                        {
                                            Br_cookie_Garden = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_22":
                                        {
                                            Br_cookie_Astick = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                    case "q16b_23":
                                        {
                                            Br_cookie_Better = Convert.ToString(record.GetValue(variable));
                                            break;
                                        }
                                }
                            }
                        }
                    }
                    if (userID != null && Weight != 0)
                    {
                        iobj.insert_Dashboard_values(userID, SurveyPeriod, Weight, SurveyID, Country, Period, Location, AgeGroup, Occupation, Gender, MaritalStatus, Education, Income, Danisa_cookie_base, BrTom, BrSpont_MayoraDanisa, BrSpont_MONDELEZChipsAhoy, BrSpont_KelsenKjeldsens, BrSpont_MONDELEZOreo, BrSpont_Glico, BrSpont_Daliyuan, BrSpont_Garden, BrSpont_Astick, BrSpont_Better, BrAid_MayoraDanisa, BrAid_MONDELEZChipsAhoy, BrAid_KelsenKjeldsens, BrAid_MONDELEZOreo, BrAid_Glico, BrAid_Daliyuan, BrAid_Garden, BrAid_Astick, BrAid_Better, AdTom, AdSpont_MayoraDanisa, AdSpont_MONDELEZChipsAhoy, AdSpont_KelsenKjeldsens, AdSpont_MONDELEZOreo, AdSpont_Glico, AdSpont_Daliyuan, AdSpont_Garden, AdSpont_Astick, AdSpont_Better, AdAid_MayoraDanisa, AdAid_MONDELEZChipsAhoy, AdAid_KelsenKjeldsens, AdAid_MONDELEZOreo, AdAid_Glico, AdAid_Daliyuan, AdAid_Garden, AdAid_Astick, AdAid_Better, Favourite_Brand, Sec_Favourite_Brand, Bumo, ConL3M_MayoraDanisa, ConL3M_MONDELEZChipsAhoy, ConL3M_KelsenKjeldsens, ConL3M_MONDELEZOreo, ConL3M_Glico, ConL3M_Daliyuan, ConL3M_Garden, ConL3M_Astick, ConL3M_Better, ConL1M_MayoraDanisa, ConL1M_MONDELEZChipsAhoy, ConL1M_KelsenKjeldsens, ConL1M_MONDELEZOreo, ConL1M_Glico, ConL1M_Daliyuan, ConL1M_Garden, ConL1M_Astick, ConL1M_Better, Recommend_Brand, q20_2, q20_1, q20_3, q20_5, q20_9, q20_14, q20_15, q20_22, q20_23, q22_2, q22_1, q22_3, q22_5, q22_9, q22_14, q22_15, q22_22, q22_23, q19, q67a_1, q67a_2, q67a_3, q67a_4, q67a_5, q67a_6, q67a_7, q67a_8, q67b, q55a, q56a_1, q56a_2, q56a_3, q56a_4, q56a_5, q56a_6, q56a_7, q56a_8, q68a_1, q68a_2, q68a_3, q68a_4, q68a_5, q68a_6, q68a_7, q68a_8, q68b, q55b, q56b_1, q56b_2, q56b_3, q56b_4, q56b_5, q56b_6, q56b_7, q56b_8, q15, q23_1_1, q23_1_2, q23_1_3, q23_1_4, q23_1_5, q23_1_6, q23_1_7, q23_1_8, q23_1_9, q23_1_10, q23_1_11, q23_1_12, q23_1_13, q23_1_14, q23_2_1, q23_2_2, q23_2_3, q23_2_4, q23_2_5, q23_2_6, q23_2_7, q23_2_8, q23_2_9, q23_2_10, q23_2_11, q23_2_12, q23_2_13, q23_2_14, q23_3_1, q23_3_2, q23_3_3, q23_3_4, q23_3_5, q23_3_6, q23_3_7, q23_3_8, q23_3_9, q23_3_10, q23_3_11, q23_3_12, q23_3_13, q23_3_14, q23_5_1, q23_5_2, q23_5_3, q23_5_4, q23_5_5, q23_5_6, q23_5_7, q23_5_8, q23_5_9, q23_5_10, q23_5_11, q23_5_12, q23_5_13, q23_5_14, q23_9_1, q23_9_2, q23_9_3, q23_9_4, q23_9_5, q23_9_6, q23_9_7, q23_9_8, q23_9_9, q23_9_10, q23_9_11, q23_9_12, q23_9_13, q23_9_14, Tom_Cookie, Br_cookie_MayoraDanisa, Br_cookie_MONDELEZChipsAhoy, Br_cookie_KelsenKjeldsens, Br_cookie_MONDELEZOreo, Br_cookie_Glico, Br_cookie_Daliyuan, Br_cookie_Garden, Br_cookie_Astick, Br_cookie_Better);
                    }

                }
            }
        }

        private static string find_UserId(int SurveyID, string SurveyPeriod, string u_id)
        {
            string sum = "";
            string[] date = SurveyPeriod.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SurveyID + sum;
        }
    }
}
