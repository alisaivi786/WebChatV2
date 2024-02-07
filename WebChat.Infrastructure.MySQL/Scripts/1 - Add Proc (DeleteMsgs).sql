CREATE DEFINER=`root`@`%` PROCEDURE `webchatv2`.`delete_old_messages`()
begin
	DECLARE cutoff_date TIMESTAMP;
    
    -- Calculate the cutoff date (7 days ago)
    SET cutoff_date = NOW() - INTERVAL 7 DAY; -- Calculate Date from current to pervious 7 days
    
    -- Delete messages older than 7 days
    DELETE FROM message WHERE DateCreated < cutoff_date;
END;