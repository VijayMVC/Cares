--select DG.DocumentGroupCode+'-'+DG.DocumentGroupName from documentgroup DG
create VIEW [dbo].[DocumentView]
AS
SELECT     D.*,DG.DocumentGroupCode,DG.DocumentGroupName,
DG.DocumentGroupCode+'-'+DG.DocumentGroupName as DocumentGroupCodeName
from Document D
inner join DocumentGroup DG on D.DocumentGroupID=DG.DocumentGroupID