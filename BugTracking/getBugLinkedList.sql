SELECT        dbo.Bugs.id, dbo.Bugs.Title, dbo.Bugs.Comment, dbo.Bugs.LocationID, dbo.DeveloperBug.BugOpen, dbo.DeveloperBug.Archived, dbo.DeveloperBug.NextBugId, dbo.Bugs.CreatedById, dbo.Bugs.previousBugID, 
                         dbo.Bugs.Priority, dbo.Bugs.AssignedUserID, (CASE WHEN previousBugId > 0 THEN
                             (SELECT        *
                               FROM            Bugs
                               WHERE        ID = previousBugId) END) AS Expr1
FROM            dbo.DeveloperBug LEFT OUTER JOIN
                         dbo.Bugs ON dbo.DeveloperBug.BugID = dbo.Bugs.id
WHERE        (dbo.Bugs.AssignedUserID = @Id) AND (dbo.DeveloperBug.BugOpen = @open)