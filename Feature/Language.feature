Feature: LanguageFeature

As a user,
I want to login and create, edit and delete a language and language level so that I can manage my language list.


@tag1
Scenario Outline: 01- Delete all records before adding any language
	Given I logged in Mars portal successfully
	When I delete all records in the language page
	

Scenario Outline: 02- Add a new language with valid details
	Given I logged in Mars portal successfully
	When I create a new '<language>' and '<language level>'
	Then the '<language>' and '<language level>' should be created successfully
	
	
	Examples: 
	| language | language level | 
	| Python   | Basic          | 

Scenario Outline: 03- Edit the existing language
	Given I logged in Mars portal successfully
	When I edit an existing '<existing Language>' and '<existing Language Level>'
	Then the '<new Language>' and '<new Language Level>' should be updated successfully
	

	Examples: 
	| existing Language | existing Language Level | new Language | new Language Level | 
	| Python            | Basic                   | Java         | Fluent             | 

Scenario Outline: 04 - Delete the existing language
	Given I logged in Mars portal successfully
	When I delete an existing '<language>'
	Then the '<message>' should be shown on the language page

	Examples: 
	| language | message |
	| Java     | Java has been deleted from your languages    |

Scenario Outline: 05 - Leave the languauge textbox empty
	Given I logged in Mars portal successfully
	When I create a new '<language>' and '<language level>'
	Then the '<message>' should be shown on the language page

	Examples: 
	| language | language level | message |
	|          | Basic          | Please enter language and level    |

Scenario Outline: 06 - Add special character in language field
	Given I logged in Mars portal successfully
	When I create a new '<language>' and '<language level>'
	Then the '<language>' and '<language level>' should be created successfully
	
	Examples: 
	| language | language level | 
	| !@#$     | Fluent         | 

Scenario Outline: 07 - Check if user able to cancel language and level field while editing the field
	Given I logged in Mars portal successfully
	When I edit an existing '<existing Language>' and '<existing Language Level>'
	Then I have to cancel by clicking cancel button

	Examples: 
	| existing Language | existing Language Level |
	| !@#$            | Fluent                   |

Scenario Outline: 08 - Add more characters
	Given I logged in Mars portal successfully
	When I create a new '<language>' and '<language level>'
	Then the '<language>' and '<language level>' should be created successfully
	
	Examples: 
	| language | language level |
		| C#!@#$%^&*(())__+":<BCXSGBBBVCGHJK<bcnabdbabna ndbddabddbanbnbdhbncajdhigi       | Basic          |
	











