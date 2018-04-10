<?php echo validation_errors(); 
echo form_open('Account/create');
echo '<h1>Inscription au rallye lecture </h1>';
echo form_label('Nom :','nom');
echo form_input('nom');
echo '<br>';
echo form_label('Prénom :','prenom');
echo form_input('prenom');
echo '<br>';
echo form_label('Email :','email');
echo form_input('email');
echo '<br>';
echo form_label('Mot de passe :','password');
echo form_input('password'); 
echo '<br>';
echo form_label('Confirmer mot de passe :','passwordConfirmation');
echo form_input('passwordConfirmation');
echo '<br>';
echo form_submit('submit','Créez votre compte');
echo form_close(); 


