using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace App_Calculator
{
    [Activity(Icon = "@drawable/CalcIcon", Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Calculator.Calculator calc = new Calculator.Calculator();
        Button dig0, dig1, dig2, dig3, dig4, dig5, dig6, dig7, dig8, dig9, digDot, divide, multiplay, plus, minus, percent, equal, raiseDigit, clean, cleanAll;
        TextView txtDisplay, txtOperation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetValues();
        }
        public void SetValues()
        {
            txtDisplay = FindViewById<TextView>(Resource.Id.txtDisplay);
            txtOperation = FindViewById<TextView>(Resource.Id.txtDisplayOperation);
            dig0 = FindViewById<Button>(Resource.Id.btn0);
            dig1 = FindViewById<Button>(Resource.Id.btn1);
            dig2 = FindViewById<Button>(Resource.Id.btn2);
            dig3 = FindViewById<Button>(Resource.Id.btn3);
            dig4 = FindViewById<Button>(Resource.Id.btn4);
            dig5 = FindViewById<Button>(Resource.Id.btn5);
            dig6 = FindViewById<Button>(Resource.Id.btn6);
            dig7 = FindViewById<Button>(Resource.Id.btn7);
            dig8 = FindViewById<Button>(Resource.Id.btn8);
            dig9 = FindViewById<Button>(Resource.Id.btn9);
            digDot = FindViewById<Button>(Resource.Id.btnDot);
            divide = FindViewById<Button>(Resource.Id.btnDivide);
            multiplay = FindViewById<Button>(Resource.Id.btnMultiplay);
            plus = FindViewById<Button>(Resource.Id.btnPlus);
            minus = FindViewById<Button>(Resource.Id.btnMinus);
            percent = FindViewById<Button>(Resource.Id.btnPercent);
            equal = FindViewById<Button>(Resource.Id.btnEqual);
            raiseDigit = FindViewById<Button>(Resource.Id.btnBackSpace);
            clean = FindViewById<Button>(Resource.Id.btnRaise);
            cleanAll = FindViewById<Button>(Resource.Id.btnRaiseAll);


            txtDisplay.Text = "";
            txtOperation.Text = "";

            dig0.Click += Dig_Click;
            dig1.Click += Dig_Click;
            dig2.Click += Dig_Click;
            dig3.Click += Dig_Click;
            dig4.Click += Dig_Click;
            dig5.Click += Dig_Click;
            dig6.Click += Dig_Click;
            dig7.Click += Dig_Click;
            dig8.Click += Dig_Click;
            dig9.Click += Dig_Click;
            digDot.Click += Dig_Click;
            divide.Click += Action_Click;
            multiplay.Click += Action_Click;
            plus.Click += Action_Click;
            minus.Click += Action_Click;
            percent.Click += Percent_Click;
            equal.Click += Equal_Click;
            raiseDigit.Click += RaiseDigit_Click;
            clean.Click += Clean_Click;
            cleanAll.Click += CleanAll_Click;
        }

        public bool IsEmpty()
        {
            return txtDisplay.Text == null || txtDisplay.Text.Equals("");
        }

        public bool MaxLength()
        {
            return txtDisplay.Length() < 8;
        }

        public bool IsPercentable()
        {
            return txtDisplay.Text.IndexOf("%") != -1;
        }

        private void CleanAll_Click(object sender, System.EventArgs e)
        {
            txtDisplay.Text = "";
            txtOperation.Text = "";
            calc.ClearAll();
        }

        private void Clean_Click(object sender, System.EventArgs e)
        {
            txtDisplay.Text = "";
        }

        public void DigitRaiser()
        {
            if (!IsEmpty())
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Length() - 1);
        }

        private void RaiseDigit_Click(object sender, System.EventArgs e)
        {
            DigitRaiser();
        }

        private void Equal_Click(object sender, System.EventArgs e)
        {
            if (!IsEmpty() && calc.FirstNumber != 0 && !txtOperation.Text.Equals(""))
            {
                if (IsPercentable())
                {
                    DigitRaiser();
                }
                calc.SecondNumber = (double.Parse(txtDisplay.Text));
                txtDisplay.Text = calc.Calculate().ToString();
                txtOperation.Text = "";
                calc.CurrentOperation = "";
                calc.LastOperation = "";
            }
        }

        private void Percent_Click(object sender, System.EventArgs e)
        {
            if (!IsEmpty() && !IsPercentable())
            {
                if (calc.FirstNumber == 0)
                {
                    txtDisplay.Text += "%";
                    calc.CurrentOperation = "%";
                }
                else if (!calc.CurrentOperation.Equals("%"))
                {
                    txtDisplay.Text += "%";
                    calc.LastOperation = "%";
                }
            }
        }

        private void Action_Click(object sender, System.EventArgs e)
        {
            if (!IsEmpty())
            {
                txtOperation.Text = ((Button)sender).Text;
                if (IsPercentable())
                {
                    DigitRaiser();
                    calc.LastOperation = (txtOperation.Text);
                }
                else
                {
                    calc.CurrentOperation = (txtOperation.Text);
                }
                calc.FirstNumber = (double.Parse(txtDisplay.Text));
                txtDisplay.Text = "";
            }
        }

        private void Dig_Click(object sender, System.EventArgs e)
        {
            if (MaxLength() && !IsPercentable())
            {
                if (((Button)sender).Text.Equals("0"))
                {
                    if (!IsEmpty())
                        txtDisplay.Text += ((Button)sender).Text;
                }
                else if (((Button)sender).Text.Equals("."))
                {
                    if(txtDisplay.Text.IndexOf(".") == -1)
                    {
                        txtDisplay.Text += ((Button)sender).Text;
                    }
                }
                else
                {
                    txtDisplay.Text += ((Button)sender).Text;
                }
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}