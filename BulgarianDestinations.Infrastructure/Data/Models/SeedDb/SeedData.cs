using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDestinations.Infrastructure.Data.Models.SeedDb
{
    internal class SeedData : SeedDestination
    {

        public SeedData() 
        {
            SeedRegions();
            SeedDestinations();
        }
        private void SeedRegions()
        {
            Blagoevgrad = new Region()
            {
                Id = 1,
                Name = "Благоевград"
            };
            Burgas = new Region()
            {
                Id = 2,
                Name = "Бургас"
            };
            Varna = new Region()
            {
                Id = 3,
                Name = "Варна"
            };
            VelikoTurnovo = new Region()
            {
                Id = 4,
                Name = "Велико Търново"
            };
            Vidin = new Region()
            {
                Id = 5,
                Name = "Видин"
            };
            Vraza = new Region()
            {
                Id = 6,
                Name = "Враца"
            };
            Gabrovo = new Region()
            {
                Id = 7,
                Name = "Габрово"
            };
            Dobrich = new Region()
            {
                Id = 8,
                Name = "Добрич"
            };
            Kardzhali = new Region()
            {
                Id = 9,
                Name = "Кърджали"
            };
            Kustendil = new Region()
            {
                Id = 10,
                Name = "Кюстендил"
            };
            Lovech = new Region()
            {
                Id = 11,
                Name = "Ловеч"
            };
            Montana = new Region()
            {
                Id = 12,
                Name = "Монтана"
            };
            Pazardzhik = new Region()
            {
                Id = 13,
                Name = "Пазарджик"
            };
            Pernik = new Region()
            {
                Id = 14,
                Name = "Перник"
            };
            Pleven = new Region()
            {
                Id = 15,
                Name = "Плевен"
            };
            Plovdiv = new Region()
            {
                Id = 16,
                Name = "Пловдив"
            };
            Razgrad = new Region()
            {
                Id = 17,
                Name = "Разград"
            };
            Ruse = new Region()
            {
                Id = 18,
                Name = "Русе"
            };
            Silistra = new Region()
            {
                Id = 19,
                Name = "Силистра"
            };
            Sliven = new Region()
            {
                Id = 20,
                Name = "Сливен"
            };
            Smolian = new Region()
            {
                Id = 21,
                Name = "Смолян"
            };
            SofiaGrad = new Region()
            {
                Id = 22,
                Name = "София - Град"
            };
            SofiaOblast = new Region()
            {
                Id = 23,
                Name = "София - Област"
            };
            StaraZagora = new Region()
            {
                Id = 24,
                Name = "Стара Загора"
            };
            Targovishte = new Region()
            {
                Id = 25,
                Name = "Търговище"
            };
            Haskovo = new Region()
            {
                Id = 26,
                Name = "Хасково"
            };
            Shumen = new Region()
            {
                Id = 27,
                Name = "Шумен"
            };
            Iambol = new Region()
            {
                Id = 28,
                Name = "Ямбол"
            };

        }

        private void SeedDestinations()
        {
            Rupite = new Destination()
            {
                Id = 1,
                Name = "Рупите - Къщата на Ванга",
                Description = "Къщата на Баба Ванга в местността Рупите е била мястото, където известната българска пророчица е приемала нуждаещите се. Малката къщичка се намира на територията на новопострения манастирския комплекс около храма на Ванга. През прозорчетата могат да да се види подредбата на стаите, мебели и вещи на Пророчицата.",
                ImageUrl = "https://i.ibb.co/Q6wvBfd/rupite.jpg",
                RegionId = 1
                
            };
        }

    }
        
}
