# drones_api


## Add Connection String Secrets

-**Initialize User Secret**
```
dotnet user-secrets init
```

-**Check User Secret**
```
dotnet user-secrets list
```

-**Add/Modify Secrets for Initial Migration**
dotnet user-secrets set "ConnectionStrings:DronesApiContext" "server=.\SQLEXPRESS; database=DroneDb; Integrated Security=true"
