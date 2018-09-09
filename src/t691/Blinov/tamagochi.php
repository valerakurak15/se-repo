<?php
session_start();

// initializing variables
$HWID = "";

// connect to the database
$db = mysqli_connect('localhost', 'id6920838_tamagochi', 'tamagochi', 'id6920838_tamagochi');
//set timezone to server
date_default_timezone_set('Europe/Moscow'); 
$date = date('Y-m-d H:i:s', time());
$HWID = mysqli_real_escape_string($db, $_POST['HWID']);
if (isset($_POST['health'])) {
      $query = "SELECT Health FROM tamagochi WHERE HWID='$HWID'";
      $result = mysqli_query($db, $query);
      $health = mysqli_fetch_row($result);
      echo "$health[0]";
      $health[0] += $_POST['health'];
      $query = "UPDATE tamagochi SET Health='$health[0]' WHERE HWID='$HWID'";
      mysqli_query($db, $query); 
  } else {
if (isset($_POST['HWID'])) {
  
  if (empty($HWID)) echo "Error to get HWID, try start program with admin laws";
  // first check the database to make sure 
  $user_check_query = "SELECT * FROM tamagochi WHERE HWID='$HWID' LIMIT 1";
  $result = mysqli_query($db, $user_check_query);
  $user = mysqli_fetch_assoc($result);
  
  if ($user['HWID'] === $HWID) { //if exist in table
      $query = "SELECT Date FROM tamagochi WHERE HWID='$HWID'";
      $result = mysqli_query($db, $query);
      $out = mysqli_fetch_row($result);
      echo "$out[0]";
      $query = "UPDATE tamagochi SET Date='$date' WHERE HWID='$HWID'";
      mysqli_query($db, $query);
      if (isset($_POST['health'])) {

      }
    }
  else {
    $query = "INSERT INTO tamagochi (HWID, Date) 
          VALUES('$HWID', '$date')";
    mysqli_query($db, $query);
}
}
}
?>
