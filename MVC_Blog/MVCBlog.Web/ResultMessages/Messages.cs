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
        }

        public static class Category
        {
            public static string AddSuccess { get => "Kategori başarıyla eklendi"; }
            public static string AddError { get => "Kategori eklenirken hata oluştu"; }
            public static string UpdateSuccess { get => "Kategori başarıyla güncellendi"; }
            public static string UpdateError { get => "Kategori güncellenirken hata oluştu"; }
            public static string? DeleteSuccess { get => "Kategori başarıyla silindi"; }
        }

        public static class User
        {
            public static string AddSuccess { get => "Kullanıcı başarıyla eklendi"; }
            public static string AddError { get => "Kullanıcı eklenirken hata oluştu"; }
            public static string UpdateSuccess { get => "Kullanıcı başarıyla güncellendi"; }
            public static string UpdateError { get => "Kullanıcı güncellenirken hata oluştu"; }
            public static string DeleteSuccess { get => "Kullanıcı başarıyla silindi"; }
        }
    }
}
