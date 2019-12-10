# MedicalSystem
Proyecto de Farmacia con el uso de patrones y web services

DEPENDIENDO DE LA INSTALACIÓN DEL SQL SERVER: 
en el archivo web.config cambiar la cadena de conexión si es sql authentication o windows authentication

//========= SQL AUTHENTICATION

<connectionStrings> 
    <add name="NombreConexionDelContext" 
       connectionString="server=<NOMBREDETUEQUIPO>;
       id=<UsuarioDeBD>;password=<PasswordDeUsuario>" 
       providerName="System.Data.SqlClient" /> 
</connectionStrings>


//========= WINDOWS AUTHENTICATION 
Reemplazar el uid y pwd por...

<connectionStrings> 
<add name="NombreConexionDelContext" 
   connectionString="server=<NOMBREDETUEQUIPO>;
   Integrated Security=SSPI;" 
   providerName="System.Data.SqlClient" /> 
</connectionStrings> 
