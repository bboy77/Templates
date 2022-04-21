// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      TodoItem.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

namespace ConsoleApplication.ConsoleUI.DataAccess.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }
}