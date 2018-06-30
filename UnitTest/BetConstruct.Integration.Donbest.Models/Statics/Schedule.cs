namespace BetConstruct.Integration.Donbest.Models.Statics.Scedule
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class don_best_sports
    {

        private string titleField;

        private uint dateField;

        private string linkField;

        private string idField;

        private string updatedField;

        private don_best_sportsSport[] scheduleField;

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public uint date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string updated
        {
            get
            {
                return this.updatedField;
            }
            set
            {
                this.updatedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("sport", IsNullable = false)]
        public don_best_sportsSport[] schedule
        {
            get
            {
                return this.scheduleField;
            }
            set
            {
                this.scheduleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSport
    {

        private don_best_sportsSportLeague[] leagueField;

        private byte idField;

        private string nameField;

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("league")]
        public don_best_sportsSportLeague[] league
        {
            get
            {
                return this.leagueField;
            }
            set
            {
                this.leagueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeague
    {

        private don_best_sportsSportLeagueLines linesField;

        private don_best_sportsSportLeagueGroup[] groupField;

        private byte idField;

        private string nameField;

        private string linkField;

        /// <remarks/>
        public don_best_sportsSportLeagueLines lines
        {
            get
            {
                return this.linesField;
            }
            set
            {
                this.linesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("group")]
        public don_best_sportsSportLeagueGroup[] group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueLines
    {

        private don_best_sportsSportLeagueLinesCurrent currentField;

        private don_best_sportsSportLeagueLinesOpen openField;

        private don_best_sportsSportLeagueLinesClose closeField;

        /// <remarks/>
        public don_best_sportsSportLeagueLinesCurrent current
        {
            get
            {
                return this.currentField;
            }
            set
            {
                this.currentField = value;
            }
        }

        /// <remarks/>
        public don_best_sportsSportLeagueLinesOpen open
        {
            get
            {
                return this.openField;
            }
            set
            {
                this.openField = value;
            }
        }

        /// <remarks/>
        public don_best_sportsSportLeagueLinesClose close
        {
            get
            {
                return this.closeField;
            }
            set
            {
                this.closeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueLinesCurrent
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueLinesOpen
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueLinesClose
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroup
    {

        private don_best_sportsSportLeagueGroupEvent[] eventField;

        private uint idField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("event")]
        public don_best_sportsSportLeagueGroupEvent[] @event
        {
            get
            {
                return this.eventField;
            }
            set
            {
                this.eventField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEvent
    {

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private uint idField;

        private string seasonField;

        private string dateField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("event_state", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("event_type", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("game_number", typeof(byte))]
        [System.Xml.Serialization.XmlElementAttribute("lines", typeof(don_best_sportsSportLeagueGroupEventLines))]
        [System.Xml.Serialization.XmlElementAttribute("live", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("location", typeof(don_best_sportsSportLeagueGroupEventLocation))]
        [System.Xml.Serialization.XmlElementAttribute("neutral", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("participant", typeof(don_best_sportsSportLeagueGroupEventParticipant))]
        [System.Xml.Serialization.XmlElementAttribute("pitcher_changed", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("score", typeof(don_best_sportsSportLeagueGroupEventScore))]
        [System.Xml.Serialization.XmlElementAttribute("time_changed", typeof(bool))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string season
        {
            get
            {
                return this.seasonField;
            }
            set
            {
                this.seasonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventLines
    {

        private don_best_sportsSportLeagueGroupEventLinesCurrent currentField;

        private don_best_sportsSportLeagueGroupEventLinesOpening openingField;

        /// <remarks/>
        public don_best_sportsSportLeagueGroupEventLinesCurrent current
        {
            get
            {
                return this.currentField;
            }
            set
            {
                this.currentField = value;
            }
        }

        /// <remarks/>
        public don_best_sportsSportLeagueGroupEventLinesOpening opening
        {
            get
            {
                return this.openingField;
            }
            set
            {
                this.openingField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventLinesCurrent
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventLinesOpening
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventLocation
    {

        private string nameField;

        private ushort idField;

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventParticipant
    {

        private don_best_sportsSportLeagueGroupEventParticipantTeam teamField;

        private bool pitcherChangedField;

        private bool pitcherChangedFieldSpecified;

        private don_best_sportsSportLeagueGroupEventParticipantPitcher pitcherField;

        private uint rotField;

        private bool rotFieldSpecified;

        private string sideField;

        private string nameField;

        private uint rotation_numberField;

        private bool rotation_numberFieldSpecified;

        /// <remarks/>
        public don_best_sportsSportLeagueGroupEventParticipantTeam team
        {
            get
            {
                return this.teamField;
            }
            set
            {
                this.teamField = value;
            }
        }

        /// <remarks/>
        public bool pitcherChanged
        {
            get
            {
                return this.pitcherChangedField;
            }
            set
            {
                this.pitcherChangedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pitcherChangedSpecified
        {
            get
            {
                return this.pitcherChangedFieldSpecified;
            }
            set
            {
                this.pitcherChangedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public don_best_sportsSportLeagueGroupEventParticipantPitcher pitcher
        {
            get
            {
                return this.pitcherField;
            }
            set
            {
                this.pitcherField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint rot
        {
            get
            {
                return this.rotField;
            }
            set
            {
                this.rotField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rotSpecified
        {
            get
            {
                return this.rotFieldSpecified;
            }
            set
            {
                this.rotFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string side
        {
            get
            {
                return this.sideField;
            }
            set
            {
                this.sideField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint rotation_number
        {
            get
            {
                return this.rotation_numberField;
            }
            set
            {
                this.rotation_numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool rotation_numberSpecified
        {
            get
            {
                return this.rotation_numberFieldSpecified;
            }
            set
            {
                this.rotation_numberFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventParticipantTeam
    {

        private string idField;

        private string nameField;

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventParticipantPitcher
    {

        private string handField;

        private uint idField;

        private string full_nameField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string hand
        {
            get
            {
                return this.handField;
            }
            set
            {
                this.handField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string full_name
        {
            get
            {
                return this.full_nameField;
            }
            set
            {
                this.full_nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class don_best_sportsSportLeagueGroupEventScore
    {

        private string linkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        event_state,

        /// <remarks/>
        event_type,

        /// <remarks/>
        game_number,

        /// <remarks/>
        lines,

        /// <remarks/>
        live,

        /// <remarks/>
        location,

        /// <remarks/>
        neutral,

        /// <remarks/>
        participant,

        /// <remarks/>
        pitcher_changed,

        /// <remarks/>
        score,

        /// <remarks/>
        time_changed,
    }



}
