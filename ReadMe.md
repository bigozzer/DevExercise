## Developer Test

Look at EventProcessorService.cs.

How can you refactor EventProcessorService to comply with SOLID?
What tests might you add around this service?
What can be done to make tests easier write against our services?

Looking for....

Split financial event validators into their own classes
Use constructor injection to create datastores and allow for better mocking
What are the dangers of calling the same request twice? Can we make it Idempotent?
