// ---------------------------------------------------------------------------------------------------------------------
// Solution:  SolutionName
// File:      DatabaseTable.cs
#if (!CompanyIsEmpty)
// Copyright: Copyright © CURRENT-YEAR COMPANY-NAME. All rights reserved.
#endif
#if (!LicenseIdentifierIsEmpty)
// License:   Licensed under the LICENSE-IDENTIFIER license. See LICENSE file for full license information.
#endif
// ---------------------------------------------------------------------------------------------------------------------

namespace WebApiApplication.Api.DataAccess.Entities;

public class DatabaseTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime DateCreated { get; set; }
}