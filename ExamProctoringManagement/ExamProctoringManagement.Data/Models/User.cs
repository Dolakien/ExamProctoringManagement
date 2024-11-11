﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExamProctoringManagement.Data.Models;

public partial class User
{
    public string UserId { get; set; }

    public string UserName { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string MainMajor { get; set; }

    public string Address { get; set; }

    public bool? Gender { get; set; }

    public DateTime? DoB { get; set; }

    public string PhoneNumber { get; set; }

    public int? RoleId { get; set; }

    public bool? Status { get; set; }
    [JsonIgnore]
    public virtual ICollection<FormSwap> FormSwaps { get; set; } = new List<FormSwap>();
    [JsonIgnore]

    public virtual ICollection<ProctoringSchedule> ProctoringSchedules { get; set; } = new List<ProctoringSchedule>();
    [JsonIgnore]

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    [JsonIgnore]

    public virtual ICollection<RegistrationForm> RegistrationForms { get; set; } = new List<RegistrationForm>();
    [JsonIgnore]

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
    [JsonIgnore]

    public virtual Role Role { get; set; }
}