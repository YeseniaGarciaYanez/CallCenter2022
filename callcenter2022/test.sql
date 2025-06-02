-- recieve call
declare @result as int;
exec spReceiveCall
	@phoneNumber = '6648337283',
	@status = @result output;
select @result;

--login agent
declare @result as int;
exec spLoginAgent
	@agentId = 1005,
	@agentPin = 2005,
	@stationId = 5,
	@status = @result output;
select @result;

--end call
declare @result as int;
exec spEndCall
	@callId = 3,
	@statusEndId = 4, -- 1: Customer Ended, 2: Agent Ended, 3: Call Dropped, 4: Tranfered (from table statusCallEnd)
	@status = @result output;
select @result;

-- calls
select * from viewCalls;
--sessions
select * from viewSessions;
-- session log
select * from viewSessionLog;
