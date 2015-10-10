==TODO==

[] Add DelegateDecompiler to solution.
[] Add AutoMaper.QueryableExtensions
[] Evaluate EntityFramework.Extended which provides Future queries, Batch, Query Result Cache and Auditing
[] Evaluate EntityFramework.InMemory when moving to EF7
[] TransactionFilter
[] Move IValidator instances into request scope...   figure out how to do this.


== Notes ==

* need uuid-ossp if using guids for ids.
	CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
	and SELECT * FROM pg_available_extensions;


== Migrations ==

* powershell Enable-Migrations
* Add-Migration / Update-Database

* Import-Module .\packages\EntityFramework\tools\EntityFramework.psd1


