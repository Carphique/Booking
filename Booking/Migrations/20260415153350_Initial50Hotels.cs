using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.Migrations
{
    /// <inheritdoc />
    public partial class Initial50Hotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "AvailableRoomsCount", "City", "ImagePath", "Name", "PricePerNight", "Rating" },
                values: new object[] { 4, "Київ", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c", "Premier Palace Hotel", 5000m, 9.1999999999999993 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AvailableRoomsCount", "City", "ImagePath", "Name", "PricePerNight", "Rating" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000002"), 2, "Київ", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006", "Hilton Kyiv", 7500m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 3, "Одеса", "https://images.unsplash.com/photo-1566073771259-6a8506099945", "M1 Club Hotel", 4500m, 9.5 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), 5, "Одеса", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9", "Bristol Hotel", 3200m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), 6, "Львів", "https://images.unsplash.com/photo-1564501049412-61c2a3083791", "Bankhotel", 4100m, 9.5999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000006"), 3, "Львів", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461", "Grand Hotel Lviv", 3800m, 9.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000007"), 7, "Харків", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Kharkiv Palace", 3500m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000008"), 4, "Харків", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "Nemo Hotel Kharkiv", 4200m, 9.0999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000009"), 10, "Дніпро", "https://images.unsplash.com/photo-1618773928121-c32242fa4703", "Menorah Hotel", 2900m, 9.3000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000010"), 2, "Дніпро", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4", "Bartolomeo Resort", 4800m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000011"), 5, "Вінниця", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c", "Hotel France", 2500m, 9.0999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000012"), 3, "Вінниця", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006", "Feride Hotel", 2800m, 8.9000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000013"), 2, "Луцьк", "https://images.unsplash.com/photo-1566073771259-6a8506099945", "Noble Boutique Hotel", 2300m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000014"), 6, "Луцьк", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9", "Zalesie Hotel", 1800m, 8.6999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000015"), 5, "Донецьк", "https://images.unsplash.com/photo-1564501049412-61c2a3083791", "Donbass Palace", 4000m, 9.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000016"), 8, "Донецьк", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461", "Victoria Hotel", 3500m, 8.8000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000017"), 12, "Житомир", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Reikartz Zhytomyr", 2100m, 8.5999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000018"), 4, "Житомир", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "Chalet Hotel", 2400m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000019"), 5, "Ужгород", "https://images.unsplash.com/photo-1618773928121-c32242fa4703", "Hotel Duet Plus", 2600m, 9.3000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000020"), 7, "Ужгород", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4", "Praha Hotel", 2200m, 8.9000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000021"), 8, "Запоріжжя", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c", "Khortitsa Palace", 3100m, 9.0999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000022"), 15, "Запоріжжя", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006", "Intourist Hotel", 1900m, 8.5 },
                    { new Guid("00000000-0000-0000-0000-000000000023"), 6, "Івано-Франківськ", "https://images.unsplash.com/photo-1566073771259-6a8506099945", "Nadiya Hotel", 2400m, 9.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000024"), 4, "Івано-Франківськ", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9", "Stanislaviv", 2000m, 8.8000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000025"), 9, "Кропивницький", "https://images.unsplash.com/photo-1564501049412-61c2a3083791", "Reikartz Kropyvnytskyi", 2200m, 8.6999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000026"), 11, "Кропивницький", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461", "Hotel Zirka", 1600m, 8.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000027"), 5, "Луганськ", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Hotel Initial", 1800m, 8.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000028"), 8, "Луганськ", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "Druzhba Hotel", 1500m, 8.0 },
                    { new Guid("00000000-0000-0000-0000-000000000029"), 7, "Миколаїв", "https://images.unsplash.com/photo-1618773928121-c32242fa4703", "Reikartz River", 2500m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000030"), 4, "Миколаїв", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4", "Palace Ukraine", 2100m, 8.5999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000031"), 3, "Полтава", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c", "Premier Hotel Palazzo", 2700m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000032"), 6, "Полтава", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006", "Reikartz Gallery", 2300m, 8.9000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000033"), 2, "Рівне", "https://images.unsplash.com/photo-1566073771259-6a8506099945", "Boutique Hotel", 2600m, 9.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000034"), 8, "Рівне", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9", "Optima Rivne", 1900m, 8.5 },
                    { new Guid("00000000-0000-0000-0000-000000000035"), 5, "Суми", "https://images.unsplash.com/photo-1564501049412-61c2a3083791", "Reikartz Sumy", 2000m, 8.8000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000036"), 3, "Суми", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461", "Shafran Hotel", 2200m, 9.0999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000037"), 6, "Тернопіль", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Avalon Palace", 2400m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000038"), 4, "Тернопіль", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "Garden Hall", 2100m, 8.5999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000039"), 10, "Херсон", "https://images.unsplash.com/photo-1618773928121-c32242fa4703", "Optima Kherson", 1800m, 8.5 },
                    { new Guid("00000000-0000-0000-0000-000000000040"), 3, "Херсон", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4", "Play Hotel by Ribas", 2300m, 9.1999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000041"), 4, "Хмельницький", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c", "Arena Hotel", 2500m, 9.0999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000042"), 2, "Хмельницький", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006", "Sobkoff Hotel", 2800m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000043"), 6, "Черкаси", "https://images.unsplash.com/photo-1566073771259-6a8506099945", "Apelsin Hotel", 2200m, 8.9000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000044"), 8, "Черкаси", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9", "Optima Cherkasy", 1900m, 8.5999999999999996 },
                    { new Guid("00000000-0000-0000-0000-000000000045"), 5, "Чернівці", "https://images.unsplash.com/photo-1564501049412-61c2a3083791", "Bukovyna Hotel", 2700m, 9.3000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000046"), 2, "Чернівці", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461", "AllureInn", 3000m, 9.5 },
                    { new Guid("00000000-0000-0000-0000-000000000047"), 7, "Чернігів", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Riverside Resort", 2400m, 9.0 },
                    { new Guid("00000000-0000-0000-0000-000000000048"), 5, "Чернігів", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "Reikartz Chernihiv", 2100m, 8.6999999999999993 },
                    { new Guid("00000000-0000-0000-0000-000000000049"), 4, "Сімферополь", "https://images.unsplash.com/photo-1618773928121-c32242fa4703", "Ukraina Hotel", 3500m, 8.8000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000050"), 2, "Ялта", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4", "Yalta Intourist", 5500m, 9.4000000000000004 },
                    { new Guid("00000000-0000-0000-0000-000000000051"), 8, "Буковель", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b", "Radisson Blu Resort", 6200m, 9.3000000000000007 },
                    { new Guid("00000000-0000-0000-0000-000000000052"), 5, "Буковель", "https://images.unsplash.com/photo-1590490359683-658d3d23f972", "F&B Spa Resort", 5100m, 9.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000020"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000021"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000022"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000023"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000024"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000025"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000026"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000027"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000028"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000029"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000030"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000031"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000032"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000033"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000034"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000035"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000036"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000037"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000038"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000039"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000040"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000041"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000042"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000043"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000044"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000045"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000046"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000047"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000048"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000049"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000050"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000051"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000052"));

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "AvailableRoomsCount", "City", "ImagePath", "Name", "PricePerNight", "Rating" },
                values: new object[] { 5, "Буковель", "https://images.unsplash.com/photo-1590490359683-658d3d23f972?w=800&q=80", "F&B Spa Resort", 5100m, 9.0 });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AvailableRoomsCount", "City", "ImagePath", "Name", "PricePerNight", "Rating" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 3, "Одеса", "https://images.unsplash.com/photo-1566073771259-6a8506099945?w=800&q=80", "M1 Club Hotel", 4500m, 9.5 },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 5, "Одеса", "https://images.unsplash.com/photo-1551882547-ff40c0d1398c?w=800&q=80", "Bristol Hotel", 3200m, 9.1999999999999993 },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 2, "Одеса", "https://images.unsplash.com/photo-1571003123894-1f0594d2b5d9?w=800&q=80", "Nemo Hotel Resort & Spa", 5800m, 9.0999999999999996 },
                    { new Guid("44444444-4444-4444-4444-444444444444"), 10, "Одеса", "https://images.unsplash.com/photo-1618773928121-c32242fa4703?w=800&q=80", "Gagarinn Hotel", 2100m, 8.5 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 4, "Київ", "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?w=800&q=80", "Premier Palace", 5000m, 9.0999999999999996 },
                    { new Guid("66666666-6666-6666-6666-666666666666"), 1, "Київ", "https://images.unsplash.com/photo-1542314831-c6a4d27ce006?w=800&q=80", "Hilton Kyiv", 7500m, 9.4000000000000004 },
                    { new Guid("77777777-7777-7777-7777-777777777777"), 6, "Львів", "https://images.unsplash.com/photo-1564501049412-61c2a3083791?w=800&q=80", "Bankhotel", 4100m, 9.5999999999999996 },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 3, "Львів", "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?w=800&q=80", "Grand Hotel Lviv", 3800m, 9.1999999999999993 },
                    { new Guid("99999999-9999-9999-9999-999999999999"), 8, "Буковель", "https://images.unsplash.com/photo-1582719478250-c89cae4dc85b?w=800&q=80", "Radisson Blu Resort", 6200m, 9.3000000000000007 }
                });
        }
    }
}
