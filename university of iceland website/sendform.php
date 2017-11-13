<!DOCTYPE html>
<html>
<head>
    <title>ng HTML and CSS | Codecademy</title>
    <meta charset='utf-8'>
</head>
<body>
<?php

if ( isset($_SERVER['HTTP_REFERER']) ) {
	if ( sizeof($_POST) > 0 )
		$form = $_POST;
	elseif ( sizeof($_GET) > 0 )
		$form = $_GET;
	else
		$form = false;

	if ( $form ) {
		echo "FORM SUBMITTED<br><br>";
		foreach ($form as $key => $value) {
			echo $key." = ".$value."<br>";
		}
		echo "<br><a href='" . $_SERVER['HTTP_REFERER'] . "'>Back</a>";
	} else {
		echo "Sorry, your form was empty.";
	}
} else {
	echo "Error: This is to HANDLE forms!";
}


?>

</body>
</html>

