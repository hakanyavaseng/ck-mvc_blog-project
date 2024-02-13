namespace MVCBlog.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string AddSuccess { get => "Makale başarıyla eklendi"; }
            public static string AddError { get => "Makale eklenirken hata oluştu"; }
            public static string UpdateSuccess { get => "Makale başarıyla güncellendi"; }
            public static string UpdateError { get => "Makale güncellenirken hata oluştu"; }
            public static string DeleteSuccess { get => "Makale başarıyla silindi"; }
            public static string DeleteError { get => "Makale silinirken hata oluştu"; }
            public static string UndoDeleteSuccess { get => "Makale başarıyla geri döndürüldü."; }
            public static string UndoDeleteError { get => "Makale geri döndürülürken hata oluştu"; }
        }

        public static class Category
        {
            public static string AddSuccess { get => "Kategori başarıyla eklendi"; }
            public static string AddError { get => "Kategori eklenirken hata oluştu"; }
            public static string UpdateSuccess { get => "Kategori başarıyla güncellendi"; }
            public static string UpdateError { get => "Kategori güncellenirken hata oluştu"; }
            public static string? DeleteSuccess { get => "Kategori başarıyla silindi"; }
            public static string? DeleteError { get => "Kategori silinirken hata oluştu"; }

            public static string UndoDeleteSuccess { get => "Kategori başarıyla geri döndürüldü."; }
            public static string UndoDeleteError { get => "Kategori geri döndürülürken hata oluştu"; }



        }

        public static class User
        {
            public static string AddSuccess { get => "Kullanıcı başarıyla eklendi"; }
            public static string AddError { get => "Kullanıcı eklenirken hata oluştu"; }
            public static string UpdateSuccess { get => "Kullanıcı başarıyla güncellendi"; }
            public static string UpdateError { get => "Kullanıcı güncellenirken hata oluştu"; }
            public static string DeleteSuccess { get => "Kullanıcı başarıyla silindi"; }
            public static string DeleteError { get => "Kullanıcı silinirken hata oluştu"; }

            public static string ChangePasswordSuccess { get => "Şifreniz başarıyla değiştirildi."; }
            public static string ChangePasswordError { get => "Şifreniz değiştirilirken hata oluştu."; }


        }
    }
}
