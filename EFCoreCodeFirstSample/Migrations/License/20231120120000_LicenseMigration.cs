using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCodeFirstSample.Migrations.License
{
    /// <inheritdoc />
    public partial class LicenseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationFriendlyId = table.Column<string>(type: "text", nullable: true),
                    LicenseName = table.Column<string>(type: "text", nullable: true),
                    LicenseType = table.Column<string>(type: "text", nullable: true),
                    LicenseStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LicenseExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<string>(type: "text", nullable: true),
                    InForce = table.Column<bool>(type: "boolean", nullable: false),
                    Attributes = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Licenses",
                columns: new[] { "Id", "AccountId", "AccountName", "Attributes", "InForce", "LicenseExpiryDate", "LicenseName", "LicenseStartDate", "LicenseType", "OrganizationFriendlyId" },
                values: new object[,]
                {
                    { new Guid("0a18a78d-5afb-4108-9cbf-bc4f43cefdf6"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 7, 2, 13, 11, 422, DateTimeKind.Unspecified).AddTicks(6060), "triallicenseworkflow", new DateTime(2023, 11, 7, 2, 13, 11, 422, DateTimeKind.Unspecified).AddTicks(5940), "Trial", "approvals11072023-87e23212-a05e-4bc6-b65c-f9ac773612ac" },
                    { new Guid("1280ea6e-6f9a-418b-9265-5ab3af58ef09"), "022784664444", "AWS", null, false, null, null, null, null, "approvals102423-test-2-ce211db6-925b-4542-ae70-b2f382423e7d" },
                    { new Guid("1941cc2f-3aee-4997-b2e6-68c89aec9340"), "001DM00002DoL24YAF", "Test Conga SIgn Acc", new Dictionary<string, object> { ["Seats"] = "50", ["TransactionLimit"] = "5000" }, true, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Conga Composer", new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Paid", "auedm0000008peo4a2-eca2ff79-ba91-4977-a195-5b3b8f675fb9" },
                    { new Guid("19f94209-a283-435c-93b4-1e6f256c2549"), "022784664444", "AWS", null, false, null, null, null, null, "approvals100523-0e665868-1d45-49b6-bc01-e877104ed2a2" },
                    { new Guid("1ac78372-86c8-4b1c-b90c-e490af783dc0"), "string", "string", null, false, null, null, null, null, "sep-11-2023-122b4029-6123-4e66-aaa1-2361d98c85be" },
                    { new Guid("23178382-fcba-48a8-bc3e-a25dde33ea71"), "022784664444", "AWS", null, false, null, null, null, null, "approvals-de-org-9a024855-9e56-4845-a273-40e6ae90346a" },
                    { new Guid("3a77c79c-19c7-43a9-b7ad-939f1c57db62"), "string", "string", null, false, null, null, null, null, "sep-6-2023-int-test-a851d6a0-dcac-45a2-9bb7-01741a1c203a" },
                    { new Guid("3faa6da8-5522-4503-bc55-2b53873ead11"), "022784664444", "AWS", null, false, null, null, null, null, "approvals091423-be8b8668-5b85-4c34-90a8-d2580c5a8b84" },
                    { new Guid("4a3cd1e3-6fff-4a55-8319-d76781b053c7"), "X0129232323", "GEHealthCare", new Dictionary<string, object> { ["NoOfUser"] = "100" }, false, new DateTime(2024, 8, 18, 13, 36, 56, 922, DateTimeKind.Utc), "CPQ", new DateTime(2023, 8, 18, 13, 36, 56, 922, DateTimeKind.Utc), "Trial", "rlscst20231020-7939680c-92f9-4a0d-977b-3815dd876471" },
                    { new Guid("4ae17e83-e69a-4d52-933a-606ef8527d04"), "001DM00002DoL24YAF", "Test Conga SIgn Acc", new Dictionary<string, object> { ["Seats"] = "-1", ["TransactionLimit"] = "30" }, true, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc), "Conga Sign", new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Trial", "auedm0000008peo4a2-eca2ff79-ba91-4977-a195-5b3b8f675fb9" },
                    { new Guid("4bdba2fe-4ee9-4458-8b67-08f43cc685bf"), "022784664444", "AWS", null, false, null, null, null, null, "approvals102423-test-41c45d81-1256-47a9-a145-5700098833d7" },
                    { new Guid("4c1586ea-5558-4917-b61d-abc80f7de3b3"), "sign-migration-nick-dev", "sign-migration-nick-dev", new Dictionary<string, object> { ["count"] = "23" }, false, new DateTime(2024, 9, 5, 17, 47, 0, 896, DateTimeKind.Utc), "sign-migration-nick-dev", new DateTime(2023, 9, 4, 17, 47, 0, 896, DateTimeKind.Utc), "trial", "sign-migration-nick-dev-36607087-77d5-46d2-9b98-3b58efb1d198" },
                    { new Guid("4f0e8871-b2df-4112-81fc-e48214a239b2"), "022784664444", "AWS", null, false, null, null, null, null, "approvals-devs-sep-5836ef65-75fe-4cd2-9e32-145e86c4e667" },
                    { new Guid("52ee06ea-83ff-4af6-97a1-0f25f7d439cc"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 10, 26, 16, 7, 21, 764, DateTimeKind.Unspecified).AddTicks(5490), "triallicenseworkflow", new DateTime(2023, 10, 26, 16, 7, 21, 764, DateTimeKind.Unspecified).AddTicks(5360), "Trial", "approvals10272023-a652c6b2-78eb-411c-afb4-d06d8b5ee6c2" },
                    { new Guid("5549a8db-1282-4a89-b14d-04aa59547154"), "022784664444", "AWS", null, false, null, null, null, null, "approvals-de-org-9a024855-9e56-4845-a273-40e6ae90346a" },
                    { new Guid("5abea323-ffc5-42be-a30d-ff1cc48c44ea"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, true, new DateTime(2023, 10, 10, 12, 35, 18, 676, DateTimeKind.Utc), "string", new DateTime(2023, 10, 9, 12, 35, 18, 676, DateTimeKind.Utc), "trial", "approval-datasync112023-f9150169-c159-4ca7-bbf7-7dee67c0a218" },
                    { new Guid("5d1d784c-5856-4561-9447-1f277c5028c1"), "022784664444", "AWS", null, false, null, null, null, null, "approvals101423-f1094b93-2481-4b77-baf5-7a3ad0880458" },
                    { new Guid("65328138-ad3f-4759-a955-6d33bb65a538"), "X0129232323", "GEHealthCare", new Dictionary<string, object> { ["NoOfUser"] = "10", ["NoOfTransaction"] = "200000" }, false, new DateTime(2024, 8, 18, 13, 36, 56, 922, DateTimeKind.Utc), "Composer", new DateTime(2023, 8, 18, 13, 36, 56, 922, DateTimeKind.Utc), "Trial", "rlscst20231020-7939680c-92f9-4a0d-977b-3815dd876471" },
                    { new Guid("715a41f6-6562-4f37-93e8-5667dc1a7629"), "022784664444", "AWS", null, false, null, null, null, null, "approvals101623-ceee1089-b521-417d-abc9-1eec6dd5b8de" },
                    { new Guid("79181611-15b8-44c4-9c8b-616316c509c0"), "022784664444", "AWS", null, false, null, null, null, null, "approvals092023-9a199ddb-de2c-4bb5-9d15-9dfc604d1bd0" },
                    { new Guid("8131630d-2fad-4781-a982-f39afb0cc963"), "022784664444", "AWS", null, false, null, null, null, null, "approvals100323-b7d414bd-32f4-40e9-86e2-cef1497882c4" },
                    { new Guid("82c325ac-8a35-433e-bbaf-e16c8c4d7576"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, true, new DateTime(2022, 10, 10, 12, 35, 18, 676, DateTimeKind.Utc), "license2", new DateTime(2022, 10, 9, 12, 35, 18, 676, DateTimeKind.Utc), "trial", "approvaldevdatasync-048b0c17-3d00-4e5d-a63e-6a37d166dfe8" },
                    { new Guid("8512d6df-9197-4e6d-ba98-40b533bc5178"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 10, 25, 19, 50, 33, 881, DateTimeKind.Unspecified).AddTicks(4180), "triallicenseworkflow", new DateTime(2023, 10, 25, 19, 50, 33, 881, DateTimeKind.Unspecified).AddTicks(4070), "Trial", "approvals102623-207b271d-3441-4ae8-95a1-1d857c31aca1" },
                    { new Guid("8db6f5c5-7076-41f8-87f0-e613278e29ad"), "022784664444", "AWS", null, false, null, null, null, null, "approvals102423-8792bcfa-1ac6-4519-8203-0881424becfb" },
                    { new Guid("8e8628e6-2cd2-4e6a-939e-869026aa19e8"), "string", "string", null, false, null, null, null, null, "test-blue-duck-july-123-604667c1-783e-46ae-9d47-eb3d8b98c9d5" },
                    { new Guid("909a9ceb-b298-469a-9e56-dcd14537ed5f"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 10, 24, 18, 50, 21, 912, DateTimeKind.Unspecified).AddTicks(2810), "triallicenseworkflow", new DateTime(2023, 10, 24, 18, 50, 21, 912, DateTimeKind.Unspecified).AddTicks(2680), "Trial", "approvals102523-656ae20b-33a5-4e84-b123-98b556e73134" },
                    { new Guid("9447d5ee-a4a0-45cb-91c3-888e4e14764f"), "022784664444", "AWS", null, false, null, null, null, null, "approvals-oct-test-13feefab-126f-461f-bea0-e64ea277e893" },
                    { new Guid("9f14df49-233c-4ed6-9237-05de9a0f90d1"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, true, new DateTime(2023, 10, 10, 12, 35, 18, 676, DateTimeKind.Utc), "string", new DateTime(2023, 10, 9, 12, 35, 18, 676, DateTimeKind.Utc), "trial", "approvaldevdatasync-048b0c17-3d00-4e5d-a63e-6a37d166dfe8" },
                    { new Guid("a59421c6-18b9-4230-809e-21291790139c"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 7, 14, 51, 36, 361, DateTimeKind.Unspecified).AddTicks(590), "triallicenseworkflow", new DateTime(2023, 11, 7, 14, 51, 36, 361, DateTimeKind.Unspecified).AddTicks(510), "Trial", "approvals11092023-2f8629a1-7773-4580-bdb3-838d00e8e497" },
                    { new Guid("a8911aa4-7cc2-4311-89db-9f8912aee4c9"), "022784664444", "AWS", null, false, null, null, null, null, "approvals092123-4cb24515-1026-4b66-ad32-1f125eb1bbc4" },
                    { new Guid("acfb9750-40b1-4829-977a-4c669a7574bd"), "001DM00002DoL24YAF", "Test Conga SIgn Acc", new Dictionary<string, object> { ["Seats"] = "51", ["TransactionLimit"] = "5000" }, true, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), "Conga Composer", new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Paid", "auedm0000008pfg4am-3be6f24d-bea5-4e2f-9435-4651a4358e5e" },
                    { new Guid("b1935426-3965-4112-aedc-8d285a6b3d1c"), "022784664444", "AWS", null, false, null, null, null, null, "approvals091523-3f1c4539-2ad1-40c0-8981-e6c43c10eb18" },
                    { new Guid("b9854942-f83a-4cff-b432-f3c707b5bf13"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 10, 26, 15, 38, 44, 78, DateTimeKind.Unspecified).AddTicks(2580), "triallicenseworkflow", new DateTime(2023, 10, 26, 15, 38, 44, 78, DateTimeKind.Unspecified).AddTicks(2470), "Trial", "approvals102723-7c8630b5-b648-4c7a-92a9-ef5525c9276a" },
                    { new Guid("c1fc1580-054e-448c-8747-cb64e396c9c6"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, false, new DateTime(2024, 9, 8, 7, 56, 21, 140, DateTimeKind.Utc), "string", new DateTime(2023, 9, 8, 7, 56, 21, 140, DateTimeKind.Utc), "trial", "customer1testing1-432e6c06-41f6-4062-a0dd-f5002aab694d" },
                    { new Guid("c44d166b-deda-48cc-9887-36038afdcf2d"), "001DM00002DoL24YAF", "Test Conga SIgn Acc", new Dictionary<string, object> { ["Seats"] = "-1", ["TransactionLimit"] = "30" }, true, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Conga Sign", new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Trial", "auedm0000008ply4am-5345e2ae-27c9-42a6-8630-d69d08167396" },
                    { new Guid("c768f394-695c-4460-8153-1cec8886579e"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 1, 14, 58, 57, 519, DateTimeKind.Unspecified).AddTicks(5420), "triallicenseworkflow", new DateTime(2023, 11, 1, 14, 58, 57, 519, DateTimeKind.Unspecified).AddTicks(5310), "Trial", "approvals110323-2712c75a-0204-4869-a245-243508d7163b" },
                    { new Guid("cb069ebc-4c64-4d2b-9121-379895831278"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 15, 21, 19, 47, 740, DateTimeKind.Unspecified).AddTicks(7130), "triallicenseworkflow", new DateTime(2023, 11, 15, 21, 19, 47, 740, DateTimeKind.Unspecified).AddTicks(7000), "Trial", "approvals11162023-65e73486-23a1-4f53-8b26-6122769830e6" },
                    { new Guid("cb7a8d3a-a785-4410-b19e-305b52a38128"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, true, new DateTime(2023, 10, 10, 12, 35, 18, 676, DateTimeKind.Utc), "string", new DateTime(2023, 10, 9, 12, 35, 18, 676, DateTimeKind.Utc), "trial", "approvaldevdatasync-048b0c17-3d00-4e5d-a63e-6a37d166dfe8" },
                    { new Guid("dae1c0dd-1e7a-42c9-80bd-4baade34fb8c"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 7, 2, 19, 39, 579, DateTimeKind.Unspecified).AddTicks(9020), "triallicenseworkflow", new DateTime(2023, 11, 7, 2, 19, 39, 579, DateTimeKind.Unspecified).AddTicks(8880), "Trial", "approvals11082023-2786e1fe-b940-43be-84d6-af8ee0fc7318" },
                    { new Guid("dfa9b3dc-5415-489b-9e08-c37ab3a2f7f0"), "022784664444", "AWS", null, false, null, null, null, null, "approvals-oct-12-2023-47d968a7-f082-4924-8015-563ad2350250" },
                    { new Guid("e16193a5-db1b-495c-9cc3-02ea0df12a6d"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 1, 17, 16, 58, 289, DateTimeKind.Unspecified).AddTicks(1370), "triallicenseworkflow", new DateTime(2023, 11, 1, 17, 16, 58, 289, DateTimeKind.Unspecified).AddTicks(1240), "Trial", "approvals11022023-1c73ca3a-041d-4952-9cc1-f6861c01d6c8" },
                    { new Guid("e1736d01-fef4-4ef3-80ff-3fe7ea3bdc74"), "022784664444", "AWS", null, false, null, null, null, null, "approvals092523-25f601b1-cf56-4aa0-8b45-9a98bf8689f4" },
                    { new Guid("e21e72d3-35ef-46b5-926d-38b82b42f535"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 16, 18, 7, 28, 421, DateTimeKind.Unspecified).AddTicks(6170), "triallicenseworkflow", new DateTime(2023, 11, 16, 18, 7, 28, 421, DateTimeKind.Unspecified).AddTicks(6090), "Trial", "approvals11172023-ff6c0285-ef06-47b6-b90c-cfbd7fa9f112" },
                    { new Guid("e3b4fe63-ce71-4e5b-8f9b-25fbcfef5e27"), "022784664444", "AWS", null, false, null, null, null, null, "approvals101323-ebe16796-7077-4a8e-ac14-f1b86feb4b72" },
                    { new Guid("f3266a0c-5796-4d39-8c30-e9abcb39be0d"), "string", "string", new Dictionary<string, object> { ["additionalProp1"] = "string", ["additionalProp2"] = "string", ["additionalProp3"] = "string" }, true, new DateTime(2023, 10, 10, 12, 35, 18, 676, DateTimeKind.Utc), "license1", new DateTime(2023, 10, 9, 12, 35, 18, 676, DateTimeKind.Utc), "trial", "approvaldevdatasync-048b0c17-3d00-4e5d-a63e-6a37d166dfe8" },
                    { new Guid("f7594c3c-cd7e-4742-954f-7701516b21d3"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 1, 14, 54, 14, 751, DateTimeKind.Unspecified).AddTicks(1100), "triallicenseworkflow", new DateTime(2023, 11, 1, 14, 54, 14, 751, DateTimeKind.Unspecified).AddTicks(1000), "Trial", "approvals-test-1102-1-036fcbba-20b7-4920-bdab-7bb95bdb586f" },
                    { new Guid("f7e50684-3db7-46ef-9de5-067f03444aaa"), "022784664444", "AWS", new Dictionary<string, object> { ["NoOfUser"] = "100", ["NoOfTransaction"] = "200000000" }, true, new DateTime(2024, 11, 9, 0, 25, 49, 551, DateTimeKind.Unspecified).AddTicks(8670), "triallicenseworkflow", new DateTime(2023, 11, 9, 0, 25, 49, 551, DateTimeKind.Unspecified).AddTicks(8570), "Trial", "approvals11102023-e3afbd68-8caa-4853-be2f-5f475d195a0b" },
                    { new Guid("f98f7382-9561-4559-8dd4-b7224ac75a0f"), "022784664444", "AWS", null, false, null, null, null, null, "approvals092623-3d670757-087a-4b49-a565-1d43c9b5c1c4" },
                    { new Guid("fa84434c-53e1-49c7-b41f-13c58f704e49"), "022784664444", "AWS", null, false, null, null, null, null, "approvals101223-7fcf1e1a-0d97-436b-95af-cd6c2a132415" },
                    { new Guid("fc78abe4-b90a-4275-974c-0e53a73a3ef5"), "string", "string", null, false, null, null, null, null, "sep-5-2023-4708a347-d351-4833-8c47-2e3ac769f1a7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licenses");
        }
    }
}
