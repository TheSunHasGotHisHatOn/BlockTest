What I've done...
------------------------------------------
1. API Tests

a. CRUD tests have been done in more traditional Arrange-Act-Assert framework because testing them in this way is easier and for simple tests is more maintainable.  It's possible in a real-life testing environment that selenium tests and api tests would work together and so would both want to use a BDD framework. For instance I may not want to use selenium to log in for every test - use of an api to log in would mean tests didn't have to be dependent on the UI login functionality. 
If this were the case the CRUD tests have been written in a way that they could easily be added into the BDD framework. 
However with the whole "you aint gonna need it", agile way of thinking in mind, the whole BDD framework adds a lot of overhead which for simple tests is overkill. So I decided to keep it simple.

Files relating to these tests can be found the directories below:
ReqresApi
Tests 
  
b. tech debt
* ReqresResponse.LogTrace: it would be good to be able to output the request and the request took as well as the RawResponse.  FiddlerCore could potentially be used for this.  Assuming the tests are run several times a day, doing this for every successful run would take up a lot of space, so it would be best to do this either when the test fails or when explicitly set to verbose mode.  
* A nice thing to do with the length of time the request took to complete would be to output it to a csv file and then graph response times.

2. Selenium Tests
As I mentioned when we met, I've not done very much work with Selenium - a month or two's work about 5 or 6 years ago.  It was as fun to do as I remembered but I ran into problems trying to click in the mouse over (quick view) and the lightbox (continue shopping/proceed to checkout).
In the time available I wasn't able to sort this out unfortunately, which was a bit of a blocker in completing the rest of the selenium tests.  I've set them up to run with specflow and there is a framework for testing against different browsers.  I've also created a basic userBuilder which currently returns a user that has an account and a user that doesn't have an account.

Files relating to these tests can be found mainly in the following directories:
BddSteps
Features
Pages

3. Reports
a. In the root directory there is a "Test" folder.  This contains the file RunTests.bat.  This file runs the tests and outputs the results (in the format yyyymmddhhmmss.xml) to a Results folder in the same directory.  It also creates a more human readable version of the report using ReportUnit which is saved in the same folder in the format yyyymmddhhmmss.html. 

b. Tech Debt
* I was hoping to create a symlink named "latest" pointing to the lastest xml file, however I'm working in Parallels on a mac, and it seems macs aren't too keen on using ntfs. 