
CREATE VIEW [dbo].[HireGroupUpGradeView]
AS
select HGUP.*,HG.HireGroupCode +'-'+HG.HireGroupName AllowedHireGroupCodeName from HireGroupUpGrade HGUP
inner join HireGroup HG on HGUP.AllowedHireGroupID=HG.HireGroupID