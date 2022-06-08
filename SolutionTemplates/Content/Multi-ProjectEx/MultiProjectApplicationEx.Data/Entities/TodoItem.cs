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

namespace MultiProjectApplicationEx.Data.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}