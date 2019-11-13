using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFinanceApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 100, nullable: false),
                    Create_At = table.Column<DateTime>(nullable: false),
                    Payment = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Color = table.Column<string>(maxLength: 60, nullable: false),
                    Image = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_At = table.Column<DateTime>(nullable: false),
                    End_At = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Number_User = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 18, nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Last_Name = table.Column<string>(maxLength: 60, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Role = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Account_Id = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Experience = table.Column<int>(nullable: true),
                    University = table.Column<string>(maxLength: 200, nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Accounts_Account_Id",
                        column: x => x.Account_Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountSubscriptions",
                columns: table => new
                {
                    Account_Id = table.Column<int>(nullable: false),
                    Subscription_Id = table.Column<int>(nullable: false),
                    Membership_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSubscriptions", x => new { x.Account_Id, x.Subscription_Id, x.Membership_Id });
                    table.ForeignKey(
                        name: "FK_AccountSubscriptions_Accounts_Account_Id",
                        column: x => x.Account_Id,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSubscriptions_Memberships_Membership_Id",
                        column: x => x.Membership_Id,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSubscriptions_Subscriptions_Subscription_Id",
                        column: x => x.Subscription_Id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Advisor_Id = table.Column<int>(nullable: false),
                    Customer_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_Advisor_Id",
                        column: x => x.Advisor_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Body = table.Column<string>(maxLength: 8000, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Create_At = table.Column<DateTime>(nullable: false),
                    Advisor_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_Advisor_Id",
                        column: x => x.Advisor_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create_At = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Note = table.Column<string>(maxLength: 100, nullable: true),
                    Customer_Id = table.Column<int>(nullable: false),
                    Category_Id = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Period = table.Column<int>(nullable: true),
                    Reach_At = table.Column<DateTime>(nullable: true),
                    Type = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registries_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registries_Users_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Create_At", "Key", "Payment" },
                values: new object[] { 1, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "2c8bab3c-6050-4247-bba0-77777b088388", true });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Name", "Number_User", "Price" },
                values: new object[,]
                {
                    { 1, "Free", 1, 0.00m },
                    { 2, "Micro Entrepreneur", 6, 12.90m },
                    { 3, "Entrepreneur", 20, 35.90m },
                    { 4, "Advisor", 1, 6.90m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Account_Id", "Active", "Discriminator", "Email", "Gender", "Last_Name", "Name", "Password", "Role", "Token", "Birthday" },
                values: new object[] { 1, 1, true, "Customer", "julio@gmail.com", 1, "Gomez", "Julio", "123456", 1, null, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubscriptions_Membership_Id",
                table: "AccountSubscriptions",
                column: "Membership_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubscriptions_Subscription_Id",
                table: "AccountSubscriptions",
                column: "Subscription_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Advisor_Id",
                table: "Appointments",
                column: "Advisor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Customer_Id",
                table: "Appointments",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Advisor_Id",
                table: "Articles",
                column: "Advisor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_Category_Id",
                table: "Registries",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Registries_Customer_Id",
                table: "Registries",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Account_Id",
                table: "Users",
                column: "Account_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountSubscriptions");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Registries");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
