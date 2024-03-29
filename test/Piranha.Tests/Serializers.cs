/*
 * Copyright (c) .NET Foundation and Contributors
 *
 * This software may be modified and distributed under the terms
 * of the MIT license. See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using Piranha.Extend.Fields;
using Piranha.Extend.Serializers;
using Piranha.Runtime;
using Xunit;

namespace Piranha.Tests;

public class Serializers
{
    public enum ColorType
    {
        Red,
        Green,
        Blue
    }

    [Fact]
    public SerializerManager Register() {
        var manager = new SerializerManager();

        manager.Register<TextField>(new StringFieldSerializer<TextField>());

        return manager;
    }

    [Fact]
    public void GetSerializer() {
        var manager = Register();

        var serializer = manager[typeof(TextField)];

        Assert.NotNull(serializer);
    }

    [Fact]
    public void UnRegister() {
        var manager = Register();

        manager.UnRegister<TextField>();

        Assert.Null(manager[typeof(TextField)]);
    }

    [Fact]
    public void SerializeCheckBoxField()
    {
        var serializer = new CheckBoxFieldSerializer<CheckBoxField>();
        var value = true;

        var str = serializer.Serialize(new CheckBoxField
        {
            Value = value
        });

        Assert.Equal(value.ToString(), str);
    }

    [Fact]
    public void DeserializeCheckBoxField()
    {
        var serializer = new CheckBoxFieldSerializer<CheckBoxField>();
        var value = true;

        var field = (CheckBoxField)serializer.Deserialize(value.ToString());

        Assert.Equal(value, field.Value);
    }

    [Fact]
    public void WrongInputCheckBoxField()
    {
        var serializer = new CheckBoxFieldSerializer<CheckBoxField>();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new DateField
        {
            Value = DateTime.Now
        }));
    }

    [Fact]
    public void SerializeDateField() {
        var serializer = new DateFieldSerializer();

        var str = serializer.Serialize(new DateField
        {
            Value = new DateTime(2001, 1, 5, 16, 0, 0)
        });

        Assert.Equal("2001-01-05", str);
    }

    [Fact]
    public void SerializeEmptyDateField() {
        var serializer = new DateFieldSerializer();

        var str = serializer.Serialize(new DateField());

        Assert.Null(str);
    }

    [Fact]
    public void DeserializeDateField() {
        var serializer = new DateFieldSerializer();
        var date = new DateTime(2001, 1, 5, 16, 0, 0);
        var str = "2001-01-05 16:00:00";

        var field = (DateField)serializer.Deserialize(str);

        Assert.NotNull(field);
        Assert.Equal(date, field.Value.Value);
    }

    [Fact]
    public void DeserializeEmptyDateField() {
        var serializer = new DateFieldSerializer();

        var field = (DateField)serializer.Deserialize(null);

        Assert.False(field.Value.HasValue);
    }

    [Fact]
    public void WrongInputToDateField() {
        var serializer = new DateFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }

    [Fact]
    public void SerializeImageField() {
        var serializer = new ImageFieldSerializer();
        var id = Guid.NewGuid();

        var str = serializer.Serialize(new ImageField
        {
            Id = id
        });

        Assert.Equal(id.ToString(), str);
    }

    [Fact]
    public void DeserializeImageField() {
        var serializer = new ImageFieldSerializer();
        var id = Guid.NewGuid();

        var field = (ImageField)serializer.Deserialize(id.ToString());

        Assert.Equal(id, field.Id.Value);
    }

    [Fact]
    public void DeserializeEmptyImageField() {
        var serializer = new ImageFieldSerializer();

        var field = (ImageField)serializer.Deserialize(null);

        Assert.False(field.HasValue);
    }

    [Fact]
    public void WrongInputToImageField() {
        var serializer = new ImageFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }

    [Fact]
    public void SerializeDocumentField() {
        var serializer = new DocumentFieldSerializer();
        var id = Guid.NewGuid();

        var str = serializer.Serialize(new DocumentField
        {
            Id = id
        });

        Assert.Equal(id.ToString(), str);
    }

    [Fact]
    public void DeserializeDocumentField() {
        var serializer = new DocumentFieldSerializer();
        var id = Guid.NewGuid();

        var field = (DocumentField)serializer.Deserialize(id.ToString());

        Assert.Equal(id, field.Id.Value);
    }

    [Fact]
    public void DeserializeEmptyDocumentField() {
        var serializer = new DocumentFieldSerializer();

        var field = (DocumentField)serializer.Deserialize(null);

        Assert.False(field.HasValue);
    }

    [Fact]
    public void WrongInputToDocumentField() {
        var serializer = new DocumentFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }

    [Fact]
    public void SerializeVideoField() {
        var serializer = new VideoFieldSerializer();
        var id = Guid.NewGuid();

        var str = serializer.Serialize(new VideoField
        {
            Id = id
        });

        Assert.Equal(id.ToString(), str);
    }

    [Fact]
    public void DeserializeVideoField() {
        var serializer = new VideoFieldSerializer();
        var id = Guid.NewGuid();

        var field = (VideoField)serializer.Deserialize(id.ToString());

        Assert.Equal(id, field.Id.Value);
    }

    [Fact]
    public void DeserializeEmptyVideoField() {
        var serializer = new VideoFieldSerializer();

        var field = (VideoField)serializer.Deserialize(null);

        Assert.False(field.HasValue);
    }

    [Fact]
    public void WrongInputToVideoField() {
        var serializer = new VideoFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }
    // START AUDIO
    [Fact]
    public void SerializeAudioField()
    {
        var serializer = new AudioFieldSerializer();
        var id = Guid.NewGuid();

        var str = serializer.Serialize(new AudioField
        {
            Id = id
        });

        Assert.Equal(id.ToString(), str);
    }

    [Fact]
    public void DeserializeAudioField()
    {
        var serializer = new AudioFieldSerializer();
        var id = Guid.NewGuid();

        var field = (AudioField)serializer.Deserialize(id.ToString());

        Assert.Equal(id, field.Id.Value);
    }

    [Fact]
    public void DeserializeEmptyAudioField()
    {
        var serializer = new AudioFieldSerializer();

        var field = (AudioField)serializer.Deserialize(null);

        Assert.False(field.HasValue);
    }

    [Fact]
    public void WrongInputToAudioField()
    {
        var serializer = new AudioFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }
    // END AUDIO
    [Fact]
    public void SerializeMediaField() {
        var serializer = new MediaFieldSerializer();
        var id = Guid.NewGuid();

        var str = serializer.Serialize(new MediaField
        {
            Id = id
        });

        Assert.Equal(id.ToString(), str);
    }

    [Fact]
    public void DeserializeMediaField() {
        var serializer = new MediaFieldSerializer();
        var id = Guid.NewGuid();

        var field = (MediaField)serializer.Deserialize(id.ToString());

        Assert.Equal(id, field.Id.Value);
    }

    [Fact]
    public void DeserializeEmptyMediaField() {
        var serializer = new MediaFieldSerializer();

        var field = (MediaField)serializer.Deserialize(null);

        Assert.False(field.HasValue);
    }

    [Fact]
    public void WrongInputToMediaField() {
        var serializer = new MediaFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }

    [Fact]
    public void SerializeNumberField() {
        var serializer = new IntegerFieldSerializer<NumberField>();

        var str = serializer.Serialize(new NumberField
        {
            Value = 25
        });

        Assert.Equal("25", str);
    }

    [Fact]
    public void SerializeEmptyNumberField() {
        var serializer = new IntegerFieldSerializer<NumberField>();

        var str = serializer.Serialize(new NumberField());

        Assert.Null(str);
    }

    [Fact]
    public void DeserializeNumberField() {
        var serializer = new IntegerFieldSerializer<NumberField>();
        var number = new NumberField
        {
            Value = 25
        };
        var str = "25";

        var field = (NumberField)serializer.Deserialize(str);

        Assert.NotNull(field);
        Assert.Equal(number.Value, field.Value);
    }

    [Fact]
    public void DeserializeEmptyNumberField() {
        var serializer = new IntegerFieldSerializer<NumberField>();

        var field = (NumberField)serializer.Deserialize(null);

        Assert.False(field.Value.HasValue);
    }

    [Fact]
    public void WrongInputToNumberField() {
        var serializer = new IntegerFieldSerializer<NumberField>();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new StringField
        {
            Value = "Exception"
        }));
    }

    [Fact]
    public void SerializeStringField() {
        var serializer = new StringFieldSerializer<StringField>();
        var ipsum = "Integer posuere erat a ante venenatis dapibus posuere velit aliquet.";

        var str = serializer.Serialize(new StringField
        {
            Value = ipsum
        });

        Assert.Equal(ipsum, str);
    }

    [Fact]
    public void DeserializeStringField() {
        var serializer = new StringFieldSerializer<StringField>();
        var ipsum = "Integer posuere erat a ante venenatis dapibus posuere velit aliquet.";

        var field = (StringField)serializer.Deserialize(ipsum);

        Assert.Equal(ipsum, field.Value);
    }

    [Fact]
    public void WrongInputStringField() {
        var serializer = new StringFieldSerializer<StringField>();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new DateField
        {
            Value = DateTime.Now
        }));
    }

    [Fact]
    public void SerializePageField() {
        var serializer = new PageFieldSerializer();
        var pageId = Guid.NewGuid();

        var str = serializer.Serialize(new PageField
        {
            Id = pageId
        });

        Assert.Equal(pageId.ToString(), str);
    }

    [Fact]
    public void DeserializePageField() {
        var serializer = new PageFieldSerializer();
        var pageId = Guid.NewGuid();

        var field = (PageField)serializer.Deserialize(pageId.ToString());

        Assert.Equal(pageId, field.Id);
    }

    [Fact]
    public void WrongInputPageField() {
        var serializer = new PageFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new DateField
        {
            Value = DateTime.Now
        }));
    }

    [Fact]
    public void SerializePostField() {
        var serializer = new PostFieldSerializer();
        var postId = Guid.NewGuid();

        var str = serializer.Serialize(new PostField
        {
            Id = postId
        });

        Assert.Equal(postId.ToString(), str);
    }

    [Fact]
    public void DeserializePostField() {
        var serializer = new PostFieldSerializer();
        var postId = Guid.NewGuid();

        var field = (PostField)serializer.Deserialize(postId.ToString());

        Assert.Equal(postId, field.Id);
    }

    [Fact]
    public void WrongInputPostField() {
        var serializer = new PostFieldSerializer();

        Assert.Throws<ArgumentException>(() => serializer.Serialize(new DateField
        {
            Value = DateTime.Now
        }));
    }

    [Fact]
    public void SerializeSelectField() {
        var serializer = new SelectFieldSerializer<SelectField<ColorType>>();

        var str = serializer.Serialize(new SelectField<ColorType>
        {
            EnumValue = ColorType.Green.ToString()
        });

        Assert.Equal("Green", str);
    }

    [Fact]
    public void DeserializeSelectField() {
        var serializer = new SelectFieldSerializer<SelectField<ColorType>>();

        var field = (SelectField<ColorType>)serializer.Deserialize("Blue");

        Assert.Equal(ColorType.Blue.ToString(), field.EnumValue);
    }

    [Fact]
    public void DeserializeEmptySelectField() {
        var serializer = new SelectFieldSerializer<SelectField<ColorType>>();

        var field = (SelectField<ColorType>)serializer.Deserialize(null);

        // Default value of the enum sequence
        Assert.Equal("Red", field.EnumValue);
    }
}
