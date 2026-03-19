using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    internal static class Program
    {
        public static Home FrmUtama;
        public static Menu FrmMenu;
        public static Page FrmPage;
        public static Discover FrmDiscover;
        public static LoginPage FrmLogin;
        public static RentPage FrmRent;
        public static RegisterPage FrmRegister;
        public static VerificationEmail FrmVerificationEmail;
        public static CommentPage FrmCommentPage;
        public static LoadingForm FrmLoading;
        public static RentingViewPage FrmRentingView;
        public static InboxForm FrmInbox;
        public static AccountPage FrmAccount;
        public static EditProfilePicture FrmEditProfilePicture;
        public static CodeItem FrmCodeItem;
        public static SessionActivityForm FrmSessionActivityForm;
        public static CashierForm FrmCashierForm;
        public static AdminEditBook FrmAdminEditBook;
        public static ProfilePictureOther FrmProfilePictureOther;
        public static BlackListForm FrmBlackListForm;
        public static UiDesign FrmUiDesign;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmUtama = new Home();
            FrmMenu = new Menu();
            FrmPage = new Page();
            FrmDiscover = new Discover();
            FrmLogin = new LoginPage();
            FrmRent = new RentPage();
            FrmRegister = new RegisterPage();
            FrmVerificationEmail = new VerificationEmail();
            FrmCommentPage = new CommentPage();
            FrmLoading = new LoadingForm();
            FrmRentingView = new RentingViewPage();
            FrmInbox = new InboxForm();
            FrmAccount = new AccountPage();
            FrmEditProfilePicture = new EditProfilePicture();
            FrmCodeItem = new CodeItem();
            FrmSessionActivityForm = new SessionActivityForm();
            FrmCashierForm = new CashierForm();
            FrmAdminEditBook = new AdminEditBook();
            FrmProfilePictureOther = new ProfilePictureOther();
            FrmBlackListForm = new BlackListForm();
            FrmUiDesign = new UiDesign();

            FrmMenu.MdiParent = FrmUtama;
            FrmPage.MdiParent = FrmUtama;
            FrmDiscover.MdiParent = FrmUtama;
            FrmRent.MdiParent = FrmUtama;
            FrmRentingView.MdiParent = FrmUtama;
            FrmInbox.MdiParent = FrmUtama;
            FrmAccount.MdiParent = FrmUtama;
            FrmCodeItem.MdiParent = FrmUtama;
            FrmSessionActivityForm.MdiParent = FrmUtama;
            FrmCashierForm.MdiParent = FrmUtama;
            FrmAdminEditBook.MdiParent = FrmUtama;
            FrmProfilePictureOther.MdiParent = FrmUtama;
            FrmBlackListForm.MdiParent = FrmUtama;
            FrmUiDesign.MdiParent = FrmUtama;

            Application.Run(FrmLoading);
        }
    }
}
