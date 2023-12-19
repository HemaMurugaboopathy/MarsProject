Feature: LanguageFeature

As a user,
I want to login and create, edit and delete a language so that I can manage my known language 

@tag1
Scenario: Add a new language with valid details
	Given I logged in Mars portal successfully
	When I navigate to language page
	When I create a new language and language level
	Then the record should be created successfully
