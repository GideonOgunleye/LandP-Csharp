Feature: Events
	As a Automation Bot
	I Want To Check For Status Codes Returned By Expired Events
	So That I Can Ensure That The Events Return The Relevant Codes

#@Smoke
Scenario: Expired Event Status Code Less Than 12 Months Old
	Given I Navigate To Url of Expired Event 'http://qa.visitlondon.com/things-to-do/event/8864150-fathers-day-in-london'
	#Then Event Should Return Status Code '200'
	Then Event Page 'Less Than 12 Months' Should Contain Text "This event has finished"
	
#@Smoke
Scenario: Expired Event Status Code More Than 12 Months Old
	Given I Navigate To Url of Expired Event 'http://qa.visitlondon.com/things-to-do/event/44448097-england-v-australia-in-the-four-nations-at-queen-elizabeth-olympic-park'
	#Then Event Should Return Status Code '401'
	Then Event Page 'Greater Than 12 Months' Should Contain Text "This event has finished"

#@Preview-Smoke
Scenario: Preview Expired Event Status Code More Than 12 Months Old
	Given I Navigate To Url of Expired Event 'http://preview-sc.visitlondon.com/things-to-do/event/44448097-england-v-australia-in-the-four-nations-at-queen-elizabeth-olympic-park'
	#Then Event Should Return Status Code '401'
	Then Event Page 'Greater Than 12 Months' Should Contain Text "This event has finished"
