USE lottery     
GO	

IF EXISTS(SELECT 1 FROM sys.views WHERE name='VW_Chat_User_Details')
DROP VIEW VW_Chat_User_Details
Go
CREATE VIEW [dbo].[VW_Chat_User_Details]
	AS
	SELECT u.UserId, u.UserName, u.NickName, u.UserPhoto
	FROM  lottery.dbo.tab_Users as u
GO