CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "AllWords" (
    "WordID" INTEGER NOT NULL CONSTRAINT "PK_AllWords" PRIMARY KEY,
    "EngWord" TEXT NOT NULL,
    "UaTranslation" TEXT NOT NULL,
    "Rating" INTEGER NOT NULL,
    "Repetition" INTEGER NOT NULL
);

CREATE TABLE "Categories" (
    "CategoryID" INTEGER NOT NULL CONSTRAINT "PK_Categories" PRIMARY KEY,
    "Name" TEXT NOT NULL,
    "CreatedAt" datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    "CanBeDeleted" INTEGER NOT NULL,
    "Deleted" INTEGER NOT NULL,
    "DeletedAt" datetime NOT NULL DEFAULT ('2000-01-01 00:00:00')
);

CREATE TABLE "Settings" (
    "SettingsID" INTEGER NOT NULL CONSTRAINT "PK_Settings" PRIMARY KEY,
    "WordCountToLearn" INTEGER NOT NULL,
    "WasLaunched" INTEGER NOT NULL,
    "WordAddingMode" INTEGER NOT NULL,
    "CurrentCategoryID" INTEGER NOT NULL,
    CONSTRAINT "FK_Settings_Categories_CurrentCategoryID" FOREIGN KEY ("CurrentCategoryID") REFERENCES "Categories" ("CategoryID")
);

CREATE TABLE "WordCategories" (
    "WordID" INTEGER NOT NULL,
    "CategoryID" INTEGER NOT NULL,
    "AddedAt" datetime NOT NULL DEFAULT (CURRENT_TIMESTAMP),
    CONSTRAINT "FK_WordCategories_AllWords_WordID" FOREIGN KEY ("WordID") REFERENCES "AllWords" ("WordID"),
    CONSTRAINT "FK_WordCategories_Categories_CategoryID" FOREIGN KEY ("CategoryID") REFERENCES "Categories" ("CategoryID")
);

CREATE INDEX "IX_Settings_CurrentCategoryID" ON "Settings" ("CurrentCategoryID");

CREATE INDEX "IX_WordCategories_CategoryID" ON "WordCategories" ("CategoryID");

CREATE INDEX "IX_WordCategories_WordID" ON "WordCategories" ("WordID");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230908185152_InitialMigration', '7.0.10');

COMMIT;

