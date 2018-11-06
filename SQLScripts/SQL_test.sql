-- ������� �������
create table A (ID int IDENTITY(1,1) not null, UserId int not null, Status int not null)

-- ��������� ������� A ��������� �������
insert into A(UserId,Status)
select 85,2
insert into A(UserId,Status)
select 85,3
insert into A(UserId,Status)
select 85,4
insert into A(UserId,Status)
select 85,5
insert into A(UserId,Status)
select 86,2
insert into A(UserId,Status)
select 86,4
insert into A(UserId,Status)
select 86,1
insert into A(UserId,Status)
select 86,3

-- ��������� ����������, ����������� ��� ������
declare @min_value int, @max_value int, @ID int, @Status int, @sum_id int

-- ������� 1.  ���������� �� ������� � ����� ��������� �������� Id, Status �� UserId = 85. �������� ��� ��������� �������� �������.

-- ������ 1:
select ID, Status from A 
where ID=(select max(ID) from A where UserId=85)

-- ������ 2:
select top 1 ID, Status from A 
where UserId=85
order by ID desc

-- ������ 3:
set @min_value=(select MIN(ID) from A where UserId=85)
set @max_value=(select MAX(ID) from A where UserId=85)
set @ID=0
set @Status=0

while @min_value<=@max_value
begin
 if @min_value>@ID
  begin
   set @ID=@min_value
   set @Status=(select Status from A where ID=@min_value)
  end
 set @min_value=@min_value+1
end

select @ID as ID, @Status as Status

-- ������ 4:
set @min_value=0
set @ID=0
set @Status=0

declare test_cursor cursor for select ID, Status from A where UserId=85

open test_cursor

fetch test_cursor into @ID, @Status

while @@FETCH_STATUS = 0
 begin
  if @ID>@min_value
   begin
    set @min_value=@ID
    set @Status=(select Status from A where ID=@min_value)
   end
  fetch next from test_cursor into @ID, @Status
 end
 
close test_cursor

deallocate test_cursor

select @ID as ID, @Status as Status

-- ������� 2. ��������� ����� ���� Id � ������������� ������ ��� UserId = 86.

-- ������ 1:
select SUM(ID) as sum_ID from A
where UserId=86

-- ������ 2:
set @min_value=(select MIN(ID) from A where UserId=86)
set @max_value=(select MAX(ID) from A where UserId=86)
set @sum_id=0

while @min_value<=@max_value
begin
 set @sum_id=@sum_id + (select ID from A where ID=@min_value and UserId=86) 
 set @min_value=@min_value+1
end

select @sum_id as sum_ID

-- ������ 3:
set @sum_id=0

declare test_cursor cursor for select ID from A where UserId=86

open test_cursor

fetch test_cursor into @ID

while @@FETCH_STATUS = 0
 begin
  set @sum_id = @sum_id + @ID
  fetch next from test_cursor into @ID
 end
 
close test_cursor

deallocate test_cursor

select @sum_id as sum_ID

-- ������� 3. ������� ������ ������ ������ �� ������� UserId.

select * from A
where ID%2=0

-- ������� �������
drop table A