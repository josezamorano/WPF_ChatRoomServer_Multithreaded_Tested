using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PresentationLayer.CustomUserControls
{
    public partial class HeaderMenuBar : UserControl
    {
        public HeaderMenuBar()
        {
            InitializeComponent();
        }




        #region Private Attributes
        private string _headerMenuBarTitle;
        private string _headerMenuBarTitleColor;

        private string _headerMenuBarDescription;
        private string _headerMenuBarDescriptionColor;

        #endregion Private Attributes


        #region Public Properties
        public string HeaderMenuBarTitle
        {
            get { return _headerMenuBarTitle; }
            set { _headerMenuBarTitle = value; }
        }

        public static readonly DependencyProperty HeaderMenuBarTitleProperty =
            DependencyProperty.Register(nameof(HeaderMenuBarTitle), typeof(string), typeof(HeaderMenuBar));


        public string HeaderMenuBarTitleColor
        {
            get { return _headerMenuBarTitleColor; }
            set { _headerMenuBarTitleColor = value; }
        }

        public static readonly DependencyProperty HeaderMEnuBarTitleColorProperty =
            DependencyProperty.Register(nameof(HeaderMenuBarTitleColor), typeof(string), typeof(HeaderMenuBar));


        public string HeaderMenuBarDescription
        {
            get { return _headerMenuBarDescription; }
            set { _headerMenuBarDescription = value; }
        }

        public static readonly DependencyProperty HeaderMenuBarDescriptionProperty =
            DependencyProperty.Register(nameof(HeaderMenuBarDescription), typeof(string), typeof(HeaderMenuBar));


        public string HeaderMenuBarDescriptionColor
        {
            get { return _headerMenuBarDescriptionColor; }
            set { _headerMenuBarDescriptionColor = value; }
        }

        public static readonly DependencyProperty HeaderMenuBarDescriptionColorProperty =
            DependencyProperty.Register(nameof(HeaderMenuBarDescriptionColor), typeof(string), typeof(HeaderMenuBar));

        #endregion Public Properties


        #region Commands
        private ICommand _headerMenuBarButtonGoBackCommand;
        public ICommand HeaderMenuBarButtonGoBackCommand
        {
            get { return _headerMenuBarButtonGoBackCommand; }
            set { _headerMenuBarButtonGoBackCommand = value; }
        }

        public static readonly DependencyProperty HeaderMenuBarButtonGoBackCommandProperty =
            DependencyProperty.Register(nameof(HeaderMenuBarButtonGoBackCommand), typeof(ICommand), typeof(HeaderMenuBar));

        #endregion Commands


    }
}
