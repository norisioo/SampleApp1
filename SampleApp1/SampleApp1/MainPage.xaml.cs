using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SampleApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            inputToList = new ObservableCollection<String>();
            inputToList.Add("test");
            //ViewのBindingContextを自分自身にする
            BindingContext = this;
            //ボタンのClickイベントにメソッドをバインドする
            button1.Clicked += button1_Clicked;
            button2.Clicked += button2_Clicked;
            //ラムダ式をバインドすることも可能
            clear.Clicked += (object sender, EventArgs e) =>
            {
                if (inputToList.Count > 0)
                {
                    inputToList.RemoveAt(0);
                    OnPropertyChanged("inputToList");
                }
            };
        }

        #region "プロパティ"
        public String input1 { get; set; }

        public int input2 { get; set; }

        public ObservableCollection<String> inputToList { get; set; }
        #endregion

        #region "イベントにバインドするメソッド"
        private void button1_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.input1))
            {
                inputToList.Add(this.input1);
                input1 = "";
                OnPropertyChanged("input1");
                OnPropertyChanged("inputToList");
            }
        }

        private void button2_Clicked(object sender, EventArgs e)
        {
            inputToList.Add(this.input2.ToString());
            input2 = 0;
            OnPropertyChanged("input2");
            OnPropertyChanged("inputToList");
        }
        #endregion

    }
}
