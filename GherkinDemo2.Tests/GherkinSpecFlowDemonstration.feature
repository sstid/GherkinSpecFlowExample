Feature: Gherkin and SpecFlow demonstration
	In order to demonstrate Gherkin and SpecFlow
	As a presenter
	I want to automate a specification

Scenario: Insert good text and validate
	Given I have entered the text "Good on ya"
	When I submit the text
	Then a success result should show

Scenario: Insert bad text and validate
	Given I have entered the text "Failure"
	When I submit the text
	Then a failure result should show

