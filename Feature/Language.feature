Feature: LanguageFeature

As a user,
I want to login and create, edit and delete a language and language level so that I can manage my language list.

@tag1
Scenario Outline: Add a new language with valid details
	Given I logged in Mars portal successfully
	When I create a new '<language>' and '<language level>'
	Then the '<language>' and '<language level>' should be created successfully
	Examples: 
	| language | language level |
	| Python  | Basic          |

Scenario Outline: Edit the existing language
	Given I logged in Mars portal successfully
	When I edit an existing '<language>' and '<language level>'
	Then the '<language>' and '<language level>' should be updated successfully

	Examples: 
	| language | language level |
	| Java  | Fluent        |

Scenario Outline: Delete the existing language
	Given I logged in Mars portal successfully
	When I delete an existing '<language>'
	Then the '<language>' should be deleted successfully





