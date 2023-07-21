using Core.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{

    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string ProductUpdated = "ürün güncellendi";
        public static string ProductDeleted = "ürün silindi";
        public static string UserNotFound = "kullanıcı  bulunamadı";
        public static string PasswordError = "şifre hatalı";
        public static string SuccessfulLogin = "giriş başarılı";
        public static string UserAlreadyExits = "kullanıcı  hazır";
        public static string UserSuccessLogin = "kullanıcı  girişi başarılı";
        public static string AccessTokenCreated = "token oluşturuldu";
    }
}
