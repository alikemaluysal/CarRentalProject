using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";

        public static string CarDeleted = "Araba silindi";

        public static string CarUpdated = "Araba güncellendi";

        public static string CarNameInvalid = "Araba ismi geçersiz";

        public static string MaintenanceTime = "Sistem bakımda";

        public static string CarsListed = "Arabalar listelendi";

        public static string InvalidYear = "Model yılı geçersiz";


        public static string RentalAdded = "Kira bilgisi eklendi";

        public static string RentalDeleted = "Kira bilgisi silindi";

        public static string RentalUpdated = "Kira bilgisi güncellendi";

        public static string CarNotReturned = "Araba teslim edimedi";

        public static string RentalsListed = "Kira bilgileri listelendi";

        public static string CarImageLimitExceded = "Her arabanın maksimum 5 resmi olabilir!";

        public static string CarImageAdded = "Araba resmi eklendi.";
        public static string CarImageDeleted = "Araba resmi kaldırıldı.";
        public static string CarImageUpdated = "Araba resmi güncellendi.";


        public static string CarImageNotFund = "Araba resmi bulunamadı.";

        public static string AuthorizationDenied = "Yetkiniz yok!";

        public static string UserRegistered = "Kullanıcı başarıyla kayıt oldu!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Şifre hatası!";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı!";
        public static string UserAlreadyExists = "Kullanıcı zaten sistemde kayıtlı!";
        public static string AccessTokenCreated = "Access Token oluşturuldu!";
    }
}
