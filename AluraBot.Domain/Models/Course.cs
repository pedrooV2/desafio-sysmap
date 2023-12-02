﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AluraBot.Domain.Models
{
    public class Course
    {
        public Course(string? title, string? description, string? url)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            Url = url;
        }

        public string Id { get; set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public string? Url { get; private set; }
        public string? TotalHour { get; private set; }
        public string? Instructor { get; private set; }
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }

        public void SetTotalHour(string value)
        {
            TotalHour = value;
        }

        public void SetInstructor(string value)
        {
            Instructor = value;
        }

        public void SetStatusMessage(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}