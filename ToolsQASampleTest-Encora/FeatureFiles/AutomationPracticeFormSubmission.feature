Feature: AutomationPracticeFormSubmission

A test for testing out autiomation code 

Scenario Outline: Test submitted form data on overlay

Given  I navigate to Automation testing form page
And I fill up "<FirstName>", "<LastName>", "<Email>", "<Gender>", "<MobileNumber>", "<DOB>", "<Subject>", "<Hobbies>", "<CurrentAddress>", "<State>" and "<City>"
And I click Submit
Then An Overlay with submitted information of form should appear 
And All the Labels from the form should be present on the Overlay
Examples: 
| FirstName | LastName  | Email             | Gender | MobileNumber | DOB         | Subject      | Hobbies | CurrentAddress      | State | City  |
| TestFname | TestLname | test123@gmail.com | Male   | 98765457765  | 12 Jan 2022 | TestSubject1 | Sports  | TestCurrent address | NCR   | Delhi |



