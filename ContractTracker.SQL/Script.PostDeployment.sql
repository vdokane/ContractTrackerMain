/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
:r .\Seed\Seed.ContractTypes.sql
:r .\Seed\Seed.ProcurementMethods.sql
:r .\Seed\Seed.MethodOfPayments.sql
:r .\Seed\Seed.TrackingSteps.sql
:r .\Seed\Seed.Units.sql
:r .\Seed\Seed.AttachmentTypes.sql
:r .\Seed\Seed.PersonTypes.sql