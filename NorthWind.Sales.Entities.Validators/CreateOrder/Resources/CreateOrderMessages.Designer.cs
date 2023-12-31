﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NorthWind.Sales.Entities.Validators.CreateOrder.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CreateOrderMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CreateOrderMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NorthWind.Sales.Entities.Validators.CreateOrder.Resources.CreateOrderMessages", typeof(CreateOrderMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe proporcionar el identificador del cliente..
        /// </summary>
        internal static string CustomerIdRequeired {
            get {
                return ResourceManager.GetString("CustomerIdRequeired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La longitud del identificador del cliente debe ser de 5..
        /// </summary>
        internal static string CustomerIdRequiredLength {
            get {
                return ResourceManager.GetString("CustomerIdRequiredLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar al menos un producto de la orden..
        /// </summary>
        internal static string OrderDetailsNoEmpty {
            get {
                return ResourceManager.GetString("OrderDetailsNoEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar los productos de la orden..
        /// </summary>
        internal static string OrderDetailsRequired {
            get {
                return ResourceManager.GetString("OrderDetailsRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar el identificador del producto..
        /// </summary>
        internal static string ProductIdGreatherThanZero {
            get {
                return ResourceManager.GetString("ProductIdGreatherThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar la cantidad ordenada del producto..
        /// </summary>
        internal static string QuantityGreatherThanZero {
            get {
                return ResourceManager.GetString("QuantityGreatherThanZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La longitud máxima de la dirección es de 60 caracteres..
        /// </summary>
        internal static string ShipAddressMaximunLength {
            get {
                return ResourceManager.GetString("ShipAddressMaximunLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe proporcionar la dirección de envío..
        /// </summary>
        internal static string ShipAddressRequired {
            get {
                return ResourceManager.GetString("ShipAddressRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La longitud máxima de la ciudad es de 15 caracteres..
        /// </summary>
        internal static string ShipCityMaximumLength {
            get {
                return ResourceManager.GetString("ShipCityMaximumLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar al menos 3 caracteres del nombre de la ciudad..
        /// </summary>
        internal static string ShipCityMinimumLenth {
            get {
                return ResourceManager.GetString("ShipCityMinimumLenth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe proporcionar la ciudad de envío..
        /// </summary>
        internal static string ShipCityRequired {
            get {
                return ResourceManager.GetString("ShipCityRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La longitud máxima del país es de 15 caracteres..
        /// </summary>
        internal static string ShipCountryMaximumLength {
            get {
                return ResourceManager.GetString("ShipCountryMaximumLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificar al menos 3 caracteres del nombre del País..
        /// </summary>
        internal static string ShipCountryMinimunLength {
            get {
                return ResourceManager.GetString("ShipCountryMinimunLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe proporcionar el país de envío..
        /// </summary>
        internal static string ShipCountryRequired {
            get {
                return ResourceManager.GetString("ShipCountryRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La longitud máxima del código postal es de 10 caracteres..
        /// </summary>
        internal static string ShipPostalCodeMaximum {
            get {
                return ResourceManager.GetString("ShipPostalCodeMaximum", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe especificarse el precio del producto..
        /// </summary>
        internal static string UnitPriceGreatherThanZero {
            get {
                return ResourceManager.GetString("UnitPriceGreatherThanZero", resourceCulture);
            }
        }
    }
}
