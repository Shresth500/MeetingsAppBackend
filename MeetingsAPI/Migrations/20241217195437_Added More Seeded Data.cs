using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetingsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    startTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    endTime = table.Column<TimeOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    MeetingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => new { x.ApplicationUserId, x.MeetingId });
                    table.ForeignKey(
                        name: "FK_Attendee_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendee_Meetings_MeetingId",
                        column: x => x.MeetingId,
                        principalTable: "Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "123456789012345678901234", 0, "e22aff06-cbed-4fd4-b766-511735614f7f", "shahrukh@example.com", true, false, null, "SHAHRUKH@EXAMPLE.COM", "SHAHRUKH KHAN", "AQAAAAIAAYagAAAAEGB3nIjVfJ6CUaNRma+9dSw8zQbFu6niOG3XG5kpjKVOJfUFkV/Sg/BO7q4wHFPnzQ==", null, false, "efeff1b7-5465-4b88-9aff-a4e63612554e", false, "Shahrukh Khan" },
                    { "123456789012345678901235", 0, "022ddd28-6512-4ad2-b6b9-e6ff46e5ce0c", "kajol@example.com", true, false, null, "KAJOL@EXAMPLE.COM", "KAJOL", "AQAAAAIAAYagAAAAEBd0F+cJuFUFz+Oj1lRZLb+JWPvTSHgTEBgo/Pv4EHB9kjk56JhkRUV4eXkSzDmiSw==", null, false, "601c1d8d-9678-496f-8e6b-a96019cd2e65", false, "Kajol" },
                    { "123456789012345678901236", 0, "308bacee-5324-497e-94bb-13d0a70a119f", "deepika@example.com", true, false, null, "DEEPIKA@EXAMPLE.COM", "DEEPIKA PADUKONE", "AQAAAAIAAYagAAAAENo+B1eSRQ8l9cIHjh4MZBjdGWP+0JmsVD2VN9dej2d7CGppr+zbyGYrUDowC1Xt4g==", null, false, "925d4937-cc7c-4b25-a060-d54502d1c2e1", false, "Deepika Padukone" },
                    { "123456789012345678901237", 0, "010a49a5-5bf0-4591-8b59-a14a940d5e42", "ranbir@example.com", true, false, null, "RANBIR@EXAMPLE.COM", "RANBIR KAPOOR", "AQAAAAIAAYagAAAAECfTaT8JAkq6zXayQMq0SAXXAFeeR4kbC4X5F9BrsEsuL951GbETMMeJ+9Dr7vO8pg==", null, false, "b871c22a-c7bb-4500-b6e2-62884dab5b65", false, "Ranbir Kapoor" },
                    { "123456789012345678901238", 0, "aac293f6-84a8-489c-a6e4-bb650c131325", "ranveer@example.com", true, false, null, "RANVEER@EXAMPLE.COM", "RANVEER SINGH", "AQAAAAIAAYagAAAAELwzE6H4PIG95f3mAEauRSA1fvuwrIWpDIBaA80MOeLUf2cSfvOWBzgwoAbCEOGiZg==", null, false, "0c32c0c3-66bc-4b4d-ba4f-31535ed79c7e", false, "Ranveer Singh" },
                    { "123456789012345678901239", 0, "e937ba1f-56cf-48bf-b736-23f79760dbe8", "amitabh@example.com", true, false, null, "AMITABH@EXAMPLE.COM", "AMITABH BACHCHAN", "AQAAAAIAAYagAAAAENGST2SE55VaYxNi9f8KpNPSUJRLvdbsbT96PqUv/bD+GEvH+TfvS/EJaGKBnJjctg==", null, false, "485e010b-011f-46ba-8f82-5f65136ea2f2", false, "Amitabh Bachchan" },
                    { "123456789012345678901240", 0, "e1e3df34-b0ed-4f16-bc8b-73806e42e0bc", "john@example.com", true, false, null, "JOHN@EXAMPLE.COM", "JOHN ABRAHAM", "AQAAAAIAAYagAAAAELnK1SVp23dwWdX/AGokSvPbeB5Z69VXgSJUmeen+Ox/eNMWwiCV7LATTF9i7wRJEg==", null, false, "0bc03afa-5ab8-479b-a6e1-62d868668f89", false, "John Abraham" },
                    { "123456789012345678901241", 0, "bad04d02-776d-403f-b2c0-013def30331f", "kohli@example.com", true, false, null, "KOHLI@EXAMPLE.COM", "VIRAT KOHLI", "AQAAAAIAAYagAAAAEHZBAKUv7TPXdbr+rSasnS8nDDaBu8ZiAzJWlircLfso98pamCvCX4gBwWwrhISJwQ==", null, false, "0221672e-21b5-4afb-b911-4ad0c3fa6b36", false, "Virat Kohli" },
                    { "123456789012345678901242", 0, "b04ee696-0b3e-4832-8f52-9209777ec52b", "dhoni@example.com", true, false, null, "DHONI@EXAMPLE.COM", "MAHENDRA SINGH DHONI", "AQAAAAIAAYagAAAAEPhVCsoOBLDXwzU30+E5iGiqRJbBU7DMCnHx/Asv+FH8MminsBjiWSQFHp592c7AZA==", null, false, "3c4f926d-8501-4c81-9afe-1517590042c3", false, "Mahendra Singh Dhoni" },
                    { "123456789012345678901243", 0, "f17aa448-7910-4c47-b550-6fce34b359d6", "dravid@example.com", true, false, null, "DRAVID@EXAMPLE.COM", "RAHUL DRAVID", "AQAAAAIAAYagAAAAECZAec9cv7I1pGMP6fxsQb0EsBYeCU5NCIqtGgxVG1ySyizhedXIeVkTtfjqFgln2Q==", null, false, "b9e27648-2f7c-4816-a710-40ed01c2fd7f", false, "Rahul Dravid" },
                    { "123456789012345678901244", 0, "ee223eeb-6688-4788-91fb-7f55bd3af999", "sachin@example.com", true, false, null, "SACHIN@EXAMPLE.COM", "SACHIN TENDULKAR", "AQAAAAIAAYagAAAAEFOzAaN+EQrzxrMrMoTSmCBG6eWv2G3aBlvpsio+Qqp3OPdO4W1dvUzikZ5Q99Oe4A==", null, false, "fed6e57e-bfd5-4095-a812-270a22998a5b", false, "Sachin Tendulkar" },
                    { "123456789012345678901245", 0, "a9cb04d0-feda-4bf1-8997-4d03d2734036", "sehwag@example.com", true, false, null, "SEHWAG@EXAMPLE.COM", "VIRENDER SEHWAG", "AQAAAAIAAYagAAAAEFtvVi3hL7baTFf8hjKiHKTUuOOhTPjev34OUt7KKu9BpBhLI6MGAgTzy92mrGJ4fw==", null, false, "af51ea32-4fff-4185-8570-e6f9217bdbf6", false, "Virender Sehwag" },
                    { "123456789012345678901246", 0, "05176ec9-ca54-4ea1-accc-2a9bbca52bf1", "bumrah@example.com", true, false, null, "BUMRAH@EXAMPLE.COM", "JASPRIT BUMRAH", "AQAAAAIAAYagAAAAEJ0BqX4hPmjcaE4fyiQp/PSEQUIXNvBl1B1S4yq/qpUlXReYNpewmj+250XFWcSRQA==", null, false, "9b7baf06-1266-4151-9285-8aa3b1d201a1", false, "Jasprit Bumrah" },
                    { "123456789012345678901247", 0, "8ec76648-2ad5-404f-b5ca-d79d82d64d16", "ashwin@example.com", true, false, null, "ASHWIN@EXAMPLE.COM", "RAVI ASHWIN", "AQAAAAIAAYagAAAAEBynEhOlhhD4raGX8tQ0Hvex8Raf7nAGjzSen4zUEi0b6I44yWmXgGsVPzbjipMbdw==", null, false, "32476916-ac42-4e06-94a8-b5c1f09c86b0", false, "Ravi Ashwin" },
                    { "123456789012345678901248", 0, "c2b1c355-788e-406e-99b5-2a5899aee387", "irfan@example.com", true, false, null, "IRFAN@EXAMPLE.COM", "IRFAN PATHAN", "AQAAAAIAAYagAAAAEFEGjvpHATjl8xltMpYci8NnfEJL1NMag30uWGRs9F4A4YHnuV1zDeTHWj95y4dIMQ==", null, false, "00d31375-a325-459f-bc97-5c4975efecef", false, "Irfan Pathan" },
                    { "123456789012345678901249", 0, "1f5bcdaa-f403-48cb-9b31-dea17d9dd89d", "aravind@example.com", true, false, null, "ARAVIND@EXAMPLE.COM", "ARAVIND VARIER", "AQAAAAIAAYagAAAAEOFNUA6dKDFqAW7gepeGTL4i/wcEkgKKH6RXMkIDDLE7ejTDMKlDwPjtv/iTx0J2Vg==", null, false, "6efb8313-a076-4928-8877-5ec004b1f96c", false, "Aravind Varier" },
                    { "123456789012345678901250", 0, "2fd3a3f3-fbdc-42ed-8279-29ad57965923", "asmita@example.com", true, false, null, "ASMITA@EXAMPLE.COM", "ASMITA CHAVAN", "AQAAAAIAAYagAAAAEOesz/WrvieOEE/jSHL7iaqDtFceQDemjA6A1d/L+qCP8bU4y50fJKjJCVN0oaamHg==", null, false, "10b37b2c-593c-474c-8715-1ed7fbb19db4", false, "Asmita Chavan" },
                    { "123456789012345678901251", 0, "6d66ab60-e548-444a-87be-9d25bd2bf008", "dhruv@example.com", true, false, null, "DHRUV@EXAMPLE.COM", "DHRUV KHANNA", "AQAAAAIAAYagAAAAEH8r0KMFl4G7JT9HiJG1jWlx/cSkcxhfg3Fh/KR4TrawQuwmC845Wvc5rcNExFB4oQ==", null, false, "bbd3db19-d89d-46df-838b-bd9f2227933f", false, "Dhruv Khanna" },
                    { "123456789012345678901252", 0, "2c773890-809f-4620-9548-1ff93d1adbac", "divya@example.com", true, false, null, "DIVYA@EXAMPLE.COM", "DIVYA NAGARE", "AQAAAAIAAYagAAAAELJf31+THTIEJA6kDk7ITmIJZgyoZDdTOfcc46WsEy3ziXX4ttP9KmsqyhUJKOGFfA==", null, false, "af5e9ae3-d197-446e-a223-d70f7e988776", false, "Divya Nagare" },
                    { "123456789012345678901253", 0, "2992e09f-959f-46fe-9f60-87ef5b4cc7f0", "gaurav@example.com", true, false, null, "GAURAV@EXAMPLE.COM", "GAURAV DEORE", "AQAAAAIAAYagAAAAEEU8FAEVYK5921NlLyc4AICzDfkt4efXWt0Lxob5DWok6imqaLtQg9byX4WTTc4ugg==", null, false, "f2a108b0-8c2f-4c43-9ed0-b9423d4066d3", false, "Gaurav Deore" },
                    { "123456789012345678901254", 0, "c642c6c7-3c76-47e5-92ce-5b1b1dedf65a", "piyush@example.com", true, false, null, "PIYUSH@EXAMPLE.COM", "PIYUSH EKLAVYA", "AQAAAAIAAYagAAAAEBkledld/m8yvhxlOGJanSuuW+CSs2mRQzKf4T4i/J8wf9qig4Su2JONKcbrRx/K7g==", null, false, "4a192126-cb0c-4b62-9369-63b872e45d71", false, "Piyush Eklavya" },
                    { "123456789012345678901255", 0, "72b1d3b8-1491-43eb-9566-34f6796323a1", "rahul@example.com", true, false, null, "RAHUL@EXAMPLE.COM", "RAHUL ANAND", "AQAAAAIAAYagAAAAENXobUxgvdHjHUclZbvgQYIIK7LyafzIpgqPKGmKPdp0u057ZJn6uLFJH5Oj2osqlw==", null, false, "06855321-fb8c-4fdf-889d-d0a68b00715b", false, "Rahul Anand" },
                    { "123456789012345678901256", 0, "b65273d9-a00a-4699-b560-27a5201430af", "sahil@example.com", true, false, null, "SAHIL@EXAMPLE.COM", "SAHIL BHOLA", "AQAAAAIAAYagAAAAEJ66uM4sgfVIoraQCYIDeFYm0VsiC22zvODcrAcx+vatO5shexx3XNVUcVzxodc6Ow==", null, false, "8fe4b565-9d29-4257-bfd8-3ef6643ab5cf", false, "Sahil Bhola" },
                    { "123456789012345678901257", 0, "45a92d2b-61f6-4aa1-b6a6-9753241be30e", "vinay@example.com", true, false, null, "VINAY@EXAMPLE.COM", "VINAY REDDY", "AQAAAAIAAYagAAAAEBOKKf7lBYE5oYVLvvyOdd6+rz0SomtI1pDbPN2MmVyLrmEImFSjE2of/T8bdQtGUg==", null, false, "13807184-cd22-4dda-bb5a-d7d1668aaf12", false, "Vinay Reddy" },
                    { "123456789012345678901258", 0, "d753c7da-6698-4af9-911d-0b1ed3846e2d", "ambani@example.com", true, false, null, "AMBANI@EXAMPLE.COM", "MUKESH AMBANI", "AQAAAAIAAYagAAAAEIBVyQzWh/3ophMd5ARAun5+6MKLGrF3ur2n93kHhpDnMP++nkMh5l7xdAqgd5Ui2g==", null, false, "0a545527-2e8a-4361-902d-4fd658cf41df", false, "Mukesh Ambani" },
                    { "123456789012345678901259", 0, "895b8b0f-d2be-4273-9cf6-e0072391cb08", "tata@example.com", true, false, null, "TATA@EXAMPLE.COM", "RATAN TATA", "AQAAAAIAAYagAAAAEByflESIU3d7gKkNSTGOWCn9zOocgXSheR49YXMT3NTwukmNxzsRVUOXqtpvbxe5vw==", null, false, "a643a695-9d39-4d61-8186-16670820b822", false, "Ratan Tata" },
                    { "123456789012345678901260", 0, "9b227fca-e8ee-4dba-a4c0-27966b85e32e", "birla@example.com", true, false, null, "BIRLA@EXAMPLE.COM", "KUMARMANGALAM BIRLA", "AQAAAAIAAYagAAAAELOXj46q70C1nF6xg0jKlCAjysS/GrlaejzWW8Bk1OEfjpqYcVSbzdpt66HDB7Uj1w==", null, false, "30f81ffc-76ba-44cb-bb5c-c9cdff85fa81", false, "Kumarmangalam Birla" },
                    { "123456789012345678901261", 0, "4fc5c263-136f-4e44-b217-b989a2210ac2", "azim@example.com", true, false, null, "AZIM@EXAMPLE.COM", "AZIM PREMJI", "AQAAAAIAAYagAAAAEJQh+UayL2vGHFo1db6iVIbMvkHxN9vSRow0ELzVhWV9zYQKCrPUQO0zbJt1nHBZ8g==", null, false, "7cbf0690-56e8-49ac-9073-56dd33781adf", false, "Azim Premji" },
                    { "123456789012345678901262", 0, "e015fd66-8ad6-4950-91b1-024c2fcc067c", "adani@example.com", true, false, null, "ADANI@EXAMPLE.COM", "GAUTAM ADANI", "AQAAAAIAAYagAAAAEDAJU2Vmy++TT8znaOrq/4Pv/WFY/f3JMRxJBOYV42DEkX6hvj6l6EIFyzmvl+sp0g==", null, false, "91bd8bb4-0979-4dcf-a060-0ef31e1e4100", false, "Gautam Adani" },
                    { "123456789012345678901263", 0, "3882b038-6df0-43f0-85ba-a38c970a2ad3", "murthy@example.com", true, false, null, "MURTHY@EXAMPLE.COM", "NARAYANA MURTHY", "AQAAAAIAAYagAAAAEGL3QxjoA36dJcioG/08fI3Gl5lH1jllaP9izrMJtnoW6aDvn0jA5VU09i+w53xp1g==", null, false, "e49972c8-f4c0-4fd5-a9ad-a0950a86cd45", false, "Narayana Murthy" }
                });

            migrationBuilder.InsertData(
                table: "Meetings",
                columns: new[] { "Id", "Date", "Description", "Name", "endTime", "startTime" },
                values: new object[,]
                {
                    { 11, new DateOnly(2020, 11, 5), "Cheers! Online party to celebrate successful completion of training.", "Post-training party", new TimeOnly(21, 30, 0), new TimeOnly(20, 0, 0) },
                    { 12, new DateOnly(2020, 10, 28), "Meeting to discuss S3 profile pic edit and upload requirements, and assign tasks", "User profile pic", new TimeOnly(10, 0, 0), new TimeOnly(9, 30, 0) },
                    { 13, new DateOnly(2020, 10, 28), "Meeting to discuss implementation of Admin features, and assign tasks", "Admin features", new TimeOnly(10, 0, 0), new TimeOnly(9, 30, 0) },
                    { 14, new DateOnly(2020, 10, 27), "Workshop on making short films by various artists at Telstra", "Short-film making workshop", new TimeOnly(20, 0, 0), new TimeOnly(18, 0, 0) },
                    { 15, new DateOnly(2020, 10, 26), "How to tire your opponents into submission yet not break a sweat", "Rock-solid defence", new TimeOnly(17, 45, 0), new TimeOnly(16, 0, 0) },
                    { 16, new DateOnly(2020, 10, 28), "Presentation on implementation of S3 profile pic edit and upload requirements", "User profile pic - Presentation", new TimeOnly(16, 0, 0), new TimeOnly(15, 15, 0) },
                    { 17, new DateOnly(2020, 10, 28), "Presentation on implementation of Admin features", "Admin features - Presentation", new TimeOnly(15, 15, 0), new TimeOnly(14, 30, 0) }
                });

            migrationBuilder.InsertData(
                table: "Attendee",
                columns: new[] { "ApplicationUserId", "MeetingId" },
                values: new object[,]
                {
                    { "123456789012345678901236", 14 },
                    { "123456789012345678901239", 14 },
                    { "123456789012345678901240", 14 },
                    { "123456789012345678901241", 15 },
                    { "123456789012345678901243", 15 },
                    { "123456789012345678901244", 15 },
                    { "123456789012345678901249", 11 },
                    { "123456789012345678901249", 13 },
                    { "123456789012345678901249", 14 },
                    { "123456789012345678901249", 17 },
                    { "123456789012345678901250", 11 },
                    { "123456789012345678901250", 13 },
                    { "123456789012345678901250", 14 },
                    { "123456789012345678901250", 17 },
                    { "123456789012345678901251", 11 },
                    { "123456789012345678901251", 12 },
                    { "123456789012345678901251", 15 },
                    { "123456789012345678901251", 16 },
                    { "123456789012345678901252", 11 },
                    { "123456789012345678901252", 12 },
                    { "123456789012345678901252", 15 },
                    { "123456789012345678901252", 16 },
                    { "123456789012345678901253", 11 },
                    { "123456789012345678901253", 12 },
                    { "123456789012345678901253", 15 },
                    { "123456789012345678901253", 16 },
                    { "123456789012345678901254", 11 },
                    { "123456789012345678901254", 13 },
                    { "123456789012345678901254", 15 },
                    { "123456789012345678901254", 17 },
                    { "123456789012345678901255", 11 },
                    { "123456789012345678901255", 12 },
                    { "123456789012345678901255", 14 },
                    { "123456789012345678901255", 16 },
                    { "123456789012345678901256", 11 },
                    { "123456789012345678901256", 12 },
                    { "123456789012345678901256", 14 },
                    { "123456789012345678901256", 16 },
                    { "123456789012345678901257", 11 },
                    { "123456789012345678901257", 13 },
                    { "123456789012345678901257", 15 },
                    { "123456789012345678901257", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendee_MeetingId",
                table: "Attendee",
                column: "MeetingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
