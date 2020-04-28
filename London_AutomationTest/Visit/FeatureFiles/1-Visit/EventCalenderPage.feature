Feature: EventCalendarPage
	In order to test a deploy
	As a visitor
	I want to check the Event calendar is and running

@Smoke
Scenario: Event calendar page is up
	Given I navigate to event calendar page '/things-to-do/whats-on/special-events/london-events-calendar'
	And I don't see an error code on Calender
	Then I should be at least one event 

@Preview-Smoke
Scenario: Preview Event calendar page is up
	Given I navigate to Preview event calendar page '/things-to-do/whats-on/special-events/london-events-calendar'
	And I don't see an error code on Calender
	Then I should be at least one event
