CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                                                       "MigrationId" character varying(150) NOT NULL,
                                                       "ProductVersion" character varying(32) NOT NULL,
                                                       CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $$
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20201218134715_InitialMigration') THEN
            CREATE TABLE "WeatherForecasts" (
                                                "Id" uuid NOT NULL,
                                                "Date" timestamp with time zone NOT NULL,
                                                "TemperatureC" integer NOT NULL,
                                                "Summary" text NULL,
                                                CONSTRAINT "PK_WeatherForecasts" PRIMARY KEY ("Id")
            );
        END IF;
    END $$;

DO $$
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20201218134715_InitialMigration') THEN
            INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
            VALUES ('20201218134715_InitialMigration', '5.0.1');
        END IF;
    END $$;
COMMIT;