// <copyright file="ViewModelBase.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Base Class to handle ViewModels.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly Dictionary<string, object?> values = new Dictionary<string, object?>();

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value>The error.</value>
        /// <exception cref="System.NotSupportedException">NotSupportedException.</exception>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        string IDataErrorInfo.Error => throw new NotSupportedException("IDataErrorInfo.Error is not supported, use IDataErrorInfo.this[propertyName] instead.");

        /// <summary>
        /// Gets a value indicating whether returns whether an exception is thrown, or if a Debug.Fail() is used
        /// when an invalid property name is passed to the VerifyPropertyName method.
        /// The default value is false, but subclasses used by unit tests might
        /// override this property's getter to return true.
        /// </summary>
        /// <value><c>true</c> if [throw on invalid property name]; otherwise, <c>false</c>.</value>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

        /// <summary>
        /// Gets the <see cref="string" /> with the specified [ERROR: invalid expression IndexerParameter.Name.Words.All].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>string.</returns>
        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return this.OnValidate(propertyName);
            }
        }

        /// <summary>
        /// Warns the developer if this object does not have
        /// a public property with the specified name. This
        /// method does not exist in a Release build.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                else
                {
                    Debug.Fail(msg);
                }
            }
        }

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <param name="value">The property value.</param>
        protected void SetValue<T>(Expression<Func<T>> propertySelector, T value)
        {
            string propertyName = this.GetPropertyName(propertySelector);

            this.SetValue<T>(propertyName, value);
        }

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The property value.</param>
        /// <exception cref="System.ArgumentException">ArgumentException.</exception>
        protected void SetValue<T>(string propertyName, T value)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            this.values[propertyName] = value!;
            this.OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertySelector">Expression tree contains the property definition.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = this.GetPropertyName(propertySelector);

            return this.GetValue<T>(propertyName);
        }

        /// <summary>
        /// Gets the value of a property.
        /// </summary>
        /// <typeparam name="T">The type of the property value.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>The value of the property or default value if not exist.</returns>
        /// <exception cref="System.ArgumentException">ArgumentException.</exception>
        protected T GetValue<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            if (!this.values.TryGetValue(propertyName, out object? value))
            {
                value = default(T);
                if (value != null)
                    this.values.Add(propertyName, value);
            }

            return (T)value!;
        }

        /// <summary>
        /// Validates current instance properties using Data Annotations.
        /// </summary>
        /// <param name="propertyName">This instance property to validate.</param>
        /// <returns>Relevant error string on validation failure or <see cref="string.Empty" /> on validation success.</returns>
        /// <exception cref="System.ArgumentException">ArgumentException.</exception>
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            string error = string.Empty;
            var value = this.GetValue(propertyName);
            var results = new List<ValidationResult>(1);
            var result = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName,
                },
                results);

            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage != null ? validationResult.ErrorMessage : string.Empty;
            }

            return error;
        }

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged!;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="propertySelector">The property selector.</param>
        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            var propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = this.GetPropertyName(propertySelector);
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>String.</returns>
        /// <exception cref="System.InvalidOperationException">InvalidOperationException.</exception>
        private string GetPropertyName(LambdaExpression expression)
        {
            if (!(expression.Body is MemberExpression memberExpression))
            {
                throw new InvalidOperationException();
            }

            return memberExpression.Member.Name;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>object.</returns>
        /// <exception cref="System.ArgumentException">ArgumentException.</exception>
        private object GetValue(string propertyName)
        {
            if (!this.values.TryGetValue(propertyName, out object? value))
            {
                var propertyDescriptor = TypeDescriptor.GetProperties(this.GetType()).Find(propertyName, false);
                if (propertyDescriptor == null)
                {
                    throw new ArgumentException("Invalid property name", propertyName);
                }

                value = propertyDescriptor.GetValue(this);
                this.values.Add(propertyName, value);
            }

            return value!;
        }
    }
}
