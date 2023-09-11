Hi there!

<h1>Migration Commands</h1>
<p>dotnet ef migrations add InitialCreate -p Infrastructure -s API -o Data/Migrations -c StoreContext<p>
<p>dotnet ef migrations add IdentityInitial -p Infrastructure -s API -o Identity/Migrations -c StoreContext<p>
<p>dotnet ef migrations add OrderEntityAdded -p Infrastructure -s API -c StoreContext<p>