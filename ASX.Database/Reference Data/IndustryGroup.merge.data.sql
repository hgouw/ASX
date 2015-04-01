-- Reference Data for IndustryGroup
MERGE INTO [dbo].[IndustryGroups] AS Target USING
(VALUES
  (N'Automobiles & Components'),
  (N'Banks'),
  (N'Capital Goods'),
  (N'Class Pend'),
  (N'Commercial Services & Supplies'),
  (N'Consumer Durables & Apparel'),
  (N'Consumer Services'),
  (N'Diversified Financials'),
  (N'Energy'),
  (N'Food & Staples Retailing'),
  (N'Food, Beverage & Tobacco'),
  (N'Health Care Equipment & Services'),
  (N'Household & Personal Products'),
  (N'Insurance'),
  (N'Materials'),
  (N'Media'),
  (N'Not Applic'),
  (N'Pharmaceuticals & Biotechnology'),
  (N'Real Estate'),
  (N'Retailing'),
  (N'Semiconductors & Semiconductor Equipment'),
  (N'Software & Services'),
  (N'Technology Hardware & Equipment'),
  (N'Telecommunication Services'),
  (N'Transportation'),
  (N'Utilities')
)
AS SOURCE ([Group])
ON Target.[Group] = Source.[Group]

-- Update matched rows
WHEN MATCHED THEN
UPDATE SET [Group] = Source.[Group]

-- Insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Group])
VALUES (Source.[Group]);