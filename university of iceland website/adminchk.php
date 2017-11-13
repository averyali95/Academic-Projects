<?php

session_start();
  
if ( !(isset($_SESSION['usernum']) && isset($_SESSION['userid']) && isset($_SESSION['level']) && $_SESSION['level'] == 1 ) )
	header('Location: /login.php', true, 302);

?>
