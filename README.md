# wolfcomHomeWork
Initial Project run for the Web API

#1. Update the database from the migration files before start of the application.

#2. To Seed data to the database Uncomment Seed services method in the Startup.cs File Line numeber 48: seeder.Seeddata();

#3. Additional Coupons Data can to add to the Data/Seed.json file.

Note: If the coupon has or Condition: 
i.e., Coupon if the applied if the customer bill is more than X amount OR if the number of customer are more than Y. 
Then split this rule into 2 rows and add.
Row1: Discount1, Xamount, null
Row2: Discount1, null, YPeople
