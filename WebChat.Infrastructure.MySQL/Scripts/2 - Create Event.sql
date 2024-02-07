CREATE EVENT delete_old_messages_event
ON SCHEDULE EVERY 1 DAY
STARTS '2024-02-08 23:59:59.000'
ON COMPLETION NOT PRESERVE
ENABLE
DO CALL delete_old_messages();