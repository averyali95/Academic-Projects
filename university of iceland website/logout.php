<?php

include("db.php");

session_start();


unset($_SESSION['usernum']);
unset($_SESSION['userid']);
unset($_SESSION['level']);

header('Location: /login.php', true, 302);

?>
