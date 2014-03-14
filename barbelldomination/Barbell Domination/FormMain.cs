//
// Copyright (c) 2012, Vaughn Friesen
// Released under the BSD License, see LICENSE for details.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Barbell_Domination
{
    public partial class FormMain : Form
    {
        List<Weight> AllWeights;
        List<Weight> WeightsUsed;
        float BarWeight = 15;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            CalculateWeights();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            AllWeights = new List<Weight>();

            AllWeights.Add(new Weight(35, 2));
            AllWeights.Add(new Weight(25, 6));
            AllWeights.Add(new Weight(10, 4));
            AllWeights.Add(new Weight(5, 4));
            AllWeights.Add(new Weight(2.5f, 4));

            StringBuilder Available = new StringBuilder("Available weights: ");

            float Total = BarWeight;

            foreach (Weight w in AllWeights)
            {
                Available.Append(w.NumberOfWeights.ToString() + "x" + w.Pounds.ToString() + ", ");
                Total += w.Pounds * w.NumberOfWeights;
            }

            Available.Append("total " + Total.ToString() + " lbs");

            labelAvailableWeights.Text = Available.ToString();

            CalculateWeights();
        }

        private int CalculateWeights(int Pounds)
        {
            WeightsUsed = new List<Weight>();
            float Needed = (float)Pounds;
            float Total = 0;

            foreach (Weight w in AllWeights)
            {
                Weight used = new Weight(w.Pounds, 0);

                int number = w.NumberOfWeights;

                while (number > 0)
                {
                    number -= 2;

                    if (Needed - w.Pounds * 2 >= 0)
                    {
                        used.NumberOfWeights += 2;
                        Needed -= w.Pounds * 2;
                        Total += w.Pounds * 2;
                    }
                }

                if (used.NumberOfWeights > 0)
                    WeightsUsed.Add(used);

                if (Pounds == 0)
                    return (int)Total;
            }

            return (int)Total;
        }

        private void CalculateWeights()
        {
            int need = (int)numericUpDownAmt.Value - (int)BarWeight;

            int mindif = 1000;
            int minx = 0;

            for (int x = 0; x < 11; x++)
            {
                int dif = Math.Abs(CalculateWeights(need + x) - need);

                if (dif == 0)
                {
                    minx = x;
                    break;
                }

                if (dif < mindif)
                {
                    mindif = dif;
                    minx = x;
                }
            }

            int Pounds = CalculateWeights(need + minx);

            StringBuilder ToUse = new StringBuilder("Use weights: ");

            foreach (Weight w in WeightsUsed)
                ToUse.Append(w.NumberOfWeights.ToString() + "x" + w.Pounds.ToString() + ", ");

            ToUse.Append("total " + (Pounds + BarWeight).ToString() + " lbs");

            labelUse.Text = ToUse.ToString();
        }
    }
}
